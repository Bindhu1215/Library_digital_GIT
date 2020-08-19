using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employee/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
                return View(_context.Employee.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId,FullName,EmpCode,Position,OfficeLocation")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                    _context.Add(employee);
                else
                    _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }











}
