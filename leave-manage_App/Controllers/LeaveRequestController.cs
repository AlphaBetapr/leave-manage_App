using AutoMapper;
using leave_manage_App.Contracts;
using leave_manage_App.Data;
using leave_manage_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App.Controllers
{

    [Authorize]

    public class LeaveRequestController : Controller
    {

        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILeaveTypeRepository _leaveTyperepo;
        private readonly ILeaveAllocationRepository _leaveAllocrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepo, IMapper mapper,
            ILeaveTypeRepository leaveTyperepo, UserManager<Employee> userManager, ILeaveAllocationRepository leaveAllocrepo)
        {

            _leaveRequestRepo = leaveRequestRepo;
            _leaveTyperepo = leaveTyperepo;
            _leaveAllocrepo = leaveAllocrepo;
            _mapper = mapper;
            _userManager = userManager;

        }


        [Authorize(Roles = "Administrator")]
        // GET: LeaveRequestController
        public ActionResult Index()
        {

            var leaveRequests = _leaveRequestRepo.FindAll();
            var leaveRequestModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);

            var model = new LeaveRequestAdminViewVM
            {

                TotalRequest = leaveRequestModel.Count,
                ApprovedRequest = leaveRequestModel.Count(q => q.Approved == true),
                PendingRequest = leaveRequestModel.Count(q => q.Approved == null),
                RejectedRequest = leaveRequestModel.Count(q => q.Approved == false),

                LeaveRequests = leaveRequestModel

            };


            return View(model);
        }

        public ActionResult MyLeave()
        {

            var user = _userManager.GetUserAsync(User).Result;
            var employeeid = user.Id;

            var allocations = _leaveAllocrepo.GetLeaveAllocationsByEmployee(employeeid);
            var allocationsModel = _mapper.Map<List<LeaveAllocationVM>>(allocations);

            var requests = _leaveRequestRepo.GetLeaveRequestsByEmployee(employeeid);
            var requestsModel = _mapper.Map<List<LeaveRequestVM>>(requests);

            var model = new LeaveRequestEmployeeViewVM
            {
                LeaveAllocations = allocationsModel,
                LeaveRequests = requestsModel
            };

            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public ActionResult Details(int id)
        {

            var leaveRequest = _leaveRequestRepo.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);

            return View(model);
        }


        public ActionResult ApproveRequest(int id)
        {
            try
            {

                var leaverequest = _leaveRequestRepo.FindById(id);

                var employeeid = leaverequest.RequestingEmployeeId;
                var leaveTypeid = leaverequest.LeaveTypeId;
                var allocation = _leaveAllocrepo.GetLeaveAllocationsByEmployeeAndType(employeeid, leaveTypeid);

                int dateRequested = (int)(leaverequest.EndDate - leaverequest.StartDate).TotalDays;

                allocation.NumberOfDays = allocation.NumberOfDays - dateRequested;

                var user = _userManager.GetUserAsync(User).Result;
                leaverequest.ApprovedById = user.Id;
                leaverequest.DateActioned = DateTime.Now;
                leaverequest.Approved = true;

                _leaveRequestRepo.Update(leaverequest);
                _leaveAllocrepo.Update(allocation);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult RejectRequest(int id)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var leaverequest = _leaveRequestRepo.FindById(id);
            leaverequest.DateActioned = DateTime.Now;
            leaverequest.ApprovedById = user.Id;
            leaverequest.Approved = false;

            _leaveRequestRepo.Update(leaverequest);

            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveRequestController/Create
        public ActionResult Create()
        {

            var leaveTypes = _leaveTyperepo.FindAll();
            var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new CreateLeaveRequestVM
            {

                LeaveTypes = leaveTypeItems

            };

            return View(model);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLeaveRequestVM model)
        {
            try
            {

                var startDate = Convert.ToDateTime(model.StartDate);
                var endDate = Convert.ToDateTime(model.EndDate);

                // this is done because -> if model state is invalid exception the return view will have LeaveTypes list
                var leaveTypes = _leaveTyperepo.FindAll();
                var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });

                model.LeaveTypes = leaveTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if(DateTime.Compare(startDate, endDate) > 1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further in the future than the End date");
                    return View(model);
                }

                var employee = _userManager.GetUserAsync(User).Result;
                var allocations = _leaveAllocrepo.GetLeaveAllocationsByEmployeeAndType(employee.Id, model.LeaveTypeId);

                int dateRequested = (int)(endDate - startDate).TotalDays;

                if (dateRequested > allocations.NumberOfDays)
                {
                    ModelState.AddModelError("", "You Do not have sufficient days for this request");
                    return View(model);
                }

                var LeaveRequestModel = new LeaveRequestVM
                {

                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = model.LeaveTypeId

                };

                var leaveRequest = _mapper.Map<LeaveHistories>(LeaveRequestModel);
                var isSuccess = _leaveRequestRepo.Create(leaveRequest);

                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong while saving the record");
                    return View(model);
                }


                return RedirectToAction("MyLeave");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
