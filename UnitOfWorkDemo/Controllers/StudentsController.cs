using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Controllers
{
    public class StudentsController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public StudentsController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Students.GetAll());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _unitOfWork.Students
                .GetById(id).ConfigureAwait(false);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
				 _unitOfWork.Students.Add(student);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            var student = await _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
			var studentFromRepo = _unitOfWork.Students.Find(x => x.Id == id);
            if (studentFromRepo==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                   _unitOfWork.Students.Modify(student);
                    await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
			var studentFromRepo = await _unitOfWork.Students.GetById(id);
			if (studentFromRepo == null)
			{
				return NotFound();
			}

			var student = _unitOfWork.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            _unitOfWork.Students.Remove(student);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
