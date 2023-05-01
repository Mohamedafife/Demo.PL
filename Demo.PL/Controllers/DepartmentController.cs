using AutoMapper;
using Demo.BLL.Interfuces;
using Demo.BLL.Repository;
using Demo.DAL.Entitys;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    //Inhartins:ParttimeEmployee is a Employee
    //Compotion:Room      has a Chira
    //The Compotion is Depanded for a Apstract class or not concret class like a [Interface]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositore _departmentRepositore;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRepositore departmentRepositore, IMapper mapper)
        {
            _departmentRepositore = departmentRepositore;
            _mapper = mapper;
            //_departmentRepositore = new DepartmentRepository();
        }
        //Department/Index => Index "Get All Department"
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepositore.Getall();
            var MappedDP = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);
            return View(MappedDP);
        }
        [HttpGet]
        public  IActionResult Create()
        {
             
            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                var MappedDP =  _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                await _departmentRepositore.Add(MappedDP);
                return  RedirectToAction(nameof(Index));
            }
           return View(departmentVM);
        }
        public async Task<IActionResult> Details(int? id,string Viewname="Details")
        {
            if(id == null)
                return BadRequest();
            var department = await _departmentRepositore.Get(id.Value);
            if (department == null)
                return BadRequest();
            var MappedDP = _mapper.Map<Department, DepartmentViewModel>(department);
            return View(Viewname, MappedDP);
        }
        // /Department/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id,"Edit");
            //if(id == null)
            //    return BadRequest();
            //    var department = _departmentRepositore.Get(id.Value);
            //if (department == null)
            //    return BadRequest();
            //return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id,DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedDP = _mapper.Map<DepartmentViewModel, Department>(departmentVM);

                    await _departmentRepositore.Update(MappedDP);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);//Not Frindly Message                   
                }
            }
            return View(departmentVM);

        }
        // /Department/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id,DepartmentViewModel departmentVM)
        {
            if (id != departmentVM.id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedDP = _mapper.Map<DepartmentViewModel, Department>(departmentVM);
                    _departmentRepositore.Delete(MappedDP);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message);//Not Frindly Message  
                }
            }
            return View(departmentVM);
        }
    }
}
