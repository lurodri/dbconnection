using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_aurora.Models;
using System.Collections.Generic;
using api_aurora.Factories;

namespace api_aurora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDetailContext _contextRW;
        private readonly StudentDetailContext _contextRO;


        public StudentController()
        {
            _contextRW = DbContextFactory.Create("DBRW");
            _contextRO = DbContextFactory.Create("DBRO");
        }

        // GET: api/StudentControllerRO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDetail>>> GetStudentDetails()
        {
            return await _contextRO.StudentDetails.ToListAsync();
        }

        // GET: api/StudentControllerRO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetail>> GetStudentDetail(int id)
        {
            var studentDetail = await _contextRO.StudentDetails.FindAsync(id);

            if (studentDetail == null)
            {
                return NotFound();
            }
            return studentDetail;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetail(int id, StudentDetail studentDetail)
        {
            if (id != studentDetail.ID)
            {
                return BadRequest();
            }

            _contextRW.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                await _contextRW.SaveChangesAsync();
            }
            catch
            {
                if (!StudentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentDetail>> PostStudentDetail(StudentDetail studentDetail)
        {
            _contextRW.StudentDetails.Add(studentDetail);
            await _contextRW.SaveChangesAsync();
            return CreatedAtAction("GetStudentDetail", new { id = studentDetail.ID }, studentDetail);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDetail>> DeleteStudentDetail(int id)
        {
            var studentDetail = await _contextRW.StudentDetails.FirstOrDefaultAsync(i => i.ID == id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            _contextRW.StudentDetails.Remove(studentDetail);
            await _contextRW.SaveChangesAsync();

            return studentDetail;
        }

        private bool StudentDetailExists(int id)
        {
            var sutdentDetail = _contextRO.StudentDetails.FirstOrDefaultAsync(i => i.ID == id);
            if (sutdentDetail == null)
                return false;
            else
                return true;
        }
    }
}
