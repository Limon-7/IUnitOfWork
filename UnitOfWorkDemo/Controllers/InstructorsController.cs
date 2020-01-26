using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Dtos;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Controllers
{
	public class InstructorsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public InstructorsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Instructors
		public async Task<IActionResult> Index(int? id, int? courseId)
		{
			var data = new InstructorIndexDto();
			data.Instructors = await _context.Instructors
				.Include(i => i.OfficeAssignment)
				.Include(i => i.CourseInstructors)
					 .ThenInclude(i => i.Course)
						//.ThenInclude(i=>i.Enrollments)
						// .ThenInclude(i => i.Student)
						//.Include(i => i.CourseInstructors)
						//.ThenInclude(i => i.Course)
						.ThenInclude(i => i.Department)
				.OrderBy(i => i.LastName)
				.ToListAsync();
			if (id != null)
			{
				ViewData["InstructorId"] = id.Value;
				Instructor instructor = data.Instructors.Where(i => i.ID == id.Value).Single();
				//to get Instructor name
				ViewBag.InstructorName = instructor.FullName;
				data.Courses = instructor.CourseInstructors.Select(s => s.Course);
			}
			if (courseId != null)
			{
				ViewBag.CourseId = courseId.Value;
				var selectedCourse = data.Courses.Where(i => i.CourseID == courseId).Single();
				// get course name
				ViewBag.CourseName = selectedCourse.Title;
				// msdn way
				//await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
				//foreach (Enrollment enrollment in selectedCourse.Enrollments)
				//{
				//	await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
				//}
				// best approach
				_context.Courses.Include(i => i.Enrollments).ThenInclude(i => i.Student).Load();
				//foreach (var item in selectedCourse.Enrollments)
				//{
				//	_context.Enrollments.Include(i => i.Student).Load();
				//}
				data.Enrollments = selectedCourse.Enrollments;
			}

			return View(data);
		}

		// GET: Instructors/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var instructor = await _context.Instructors
				.FirstOrDefaultAsync(m => m.ID == id);
			if (instructor == null)
			{
				return NotFound();
			}

			return View(instructor);
		}

		// GET: Instructors/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Instructors/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,LastName,FirstNmae,HireDate")] Instructor instructor)
		{
			if (ModelState.IsValid)
			{
				_context.Add(instructor);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(instructor);
		}

		// GET: Instructors/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var instructor = await _context.Instructors.Include(i => i.OfficeAssignment).AsNoTracking().FirstOrDefaultAsync(i => i.ID == id);
			if (instructor == null)
			{
				return NotFound();
			}
			return View(instructor);
		}
/// <summary>
/// 
/// </summary>
/// <param name="id">Multiple data updated</param>
/// <returns></returns>
		[HttpPost, ActionName("Edit")]
		 [ValidateAntiForgeryToken]
		 public async Task<IActionResult> EditPost(int? id)
		 {
			 if (id == null)
			 {
				 return NotFound();
			 }
			var instructor = await _context.Instructors.Include(i => i.OfficeAssignment).AsNoTracking().FirstOrDefaultAsync(i => i.ID == id);
			if (instructor == null)
			{
				return NotFound();
			}
			//	 update reletaed data
			if(await TryUpdateModelAsync<Instructor>
				(instructor,"", i=>i.FirstNmae,i=>i.LastName,i=>i.HireDate,i=>i.OfficeAssignment))
			{
				if (String.IsNullOrWhiteSpace(instructor.OfficeAssignment?.Location)) 
				{
					instructor.OfficeAssignment = null;
				}
				if(ModelState.IsValid)
				{
					try
					{
						await _context.SaveChangesAsync();
					}
					catch (Exception)
					{

						throw;
					}
					return RedirectToAction("Index");
				}
			}
			return View(instructor);
		 }
		
		// GET: Instructors/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var instructor = await _context.Instructors
				.FirstOrDefaultAsync(m => m.ID == id);
			if (instructor == null)
			{
				return NotFound();
			}

			return View(instructor);
		}

		// POST: Instructors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var instructor = await _context.Instructors.FindAsync(id);
			_context.Instructors.Remove(instructor);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool InstructorExists(int id)
		{
			return _context.Instructors.Any(e => e.ID == id);
		}
	}
}
