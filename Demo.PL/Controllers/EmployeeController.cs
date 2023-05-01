using AutoMapper;
using Demo.BLL.Interfuces;
using Demo.BLL.Repository;
using Demo.DAL.Entitys;
using Demo.PL.Helpers;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepositore _departmentRepositore;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepositore departmentRepositore, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepositore = departmentRepositore;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var employee =await _employeeRepository.Getall();
                var MappedEp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);
                return View(MappedEp);
            }
            else
            {
                var employee = 
                    _employeeRepository.GetEmployeeByName(SearchValue);
                var MappedEp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);
                return View(MappedEp);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.department =await _departmentRepositore.Getall();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                //Manual Mapping
                //var MappedEp = new Employee()
                //{
                //    Name = employeeViewModel.Name,
                //    Age = employeeViewModel.Age,
                //    Address = employeeViewModel.Address,
                //    Email = employeeViewModel.Email,
                //    Salary = employeeViewModel.Salary,
                //    PhoneNumber = employeeViewModel.PhoneNumber,
                //    IsValed = employeeViewModel.IsValed,
                //    DepartmentId = employeeViewModel.DepartmentId,
                //};
                employeeVM.ImageName =  DocumentsSessting.UploadFile((Microsoft.AspNetCore.Http.FormFile)employeeVM.Image, "Images");
                var MappedEp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);
                await _employeeRepository.Add(MappedEp);
                TempData["Message"] = "Employee is Sccecfuly";
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")

        {
            if (id == null)
                return BadRequest();
            var employee = await _employeeRepository.Get(id.Value);
            if (employee == null)
                return BadRequest();
            var MappedEp = _mapper.Map<Employee,EmployeeViewModel>(employee);
            return View(MappedEp);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.department =await _departmentRepositore.Getall();
            return await Details(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    await  _employeeRepository.Update(MappedEp);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employeeVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    int Count = await _employeeRepository.Delete(MappedEp);
                    if (Count > 0)
                        DocumentsSessting.DeleteFile(employeeVM.ImageName, "Images");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employeeVM);

        }
    }
}
