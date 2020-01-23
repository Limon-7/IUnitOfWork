using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Dtos;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Controllers
{
    public class StudentsController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public StudentsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Students.GetAll());
        }

		// GET: Students/Details/5
		public async Task<IActionResult> Details(int id=0)
        {
            if (id <= 0)
            {
                return NotFound();
            }

			var student = await _unitOfWork.Students.StudentWithEnrollment(id);
			//var student = await _context.Students.Include(p => p.Enrollments).ThenInclude(p=>p.Course).ThenInclude(p=>p.Department).FirstOrDefaultAsync(p=>p.Id==id);
			ViewBag.id = id;
            if (student == null)
            {
                return NotFound();
            }
			var studentFromRepo = _mapper.Map<StudentsForDetailedDto>(student);
            return View(studentFromRepo);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,FirstNmae,EnrollmentDate")] StudentForCreationDto student)
        {
            if (ModelState.IsValid)
            {
				var studentToCreate = _mapper.Map<Student>(student);
                _unitOfWork.Students.Add(studentToCreate);
                await _unitOfWork.Complete();
				var studentFromRepo = _mapper.Map<StudentsForDetailedDto>(studentToCreate);
				//int id = studentToCreate.Id;
				return RedirectToAction(nameof(Index));
			}
            return View(student);
        }

        // GET: Students/Edit/5
		
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var student = await _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
		/// <summary>
		/// Probelm
		/// </summary>
		/// <param name="id">View data is unavailable</param>
		/// <param name="dto"></param>
		/// <returns></returns>
        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastName,FirstNmae")] StudentsForEditDto dto)
        {
			var student = await _unitOfWork.Students.GetById(id);
            if (student==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					var studentforUpdate = _mapper.Map(dto,student);
                    _unitOfWork.Students.Modify(studentforUpdate);
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var student = await _unitOfWork.Students.GetById(id);
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
