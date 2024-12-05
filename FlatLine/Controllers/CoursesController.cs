using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlatLine.Data;
using FlatLine.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FlatLine.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortDescription,LongDescription,Author,Price,Duration")] Course course, IFormFile profilePicture)
        {
            if (ModelState.IsValid)
            {
                course.Id = Guid.NewGuid(); // Generate a new unique ID

                if (profilePicture != null && profilePicture.Length > 0)
                {
                    // Handle file upload and convert it to byte[] for storage in the database
                    using (var memoryStream = new MemoryStream())
                    {
                        await profilePicture.CopyToAsync(memoryStream);
                        course.ProfilePicture = memoryStream.ToArray(); // Store image as byte[]
                        course.ProfilePictureFileName = profilePicture.FileName; // Store file name
                        course.ProfilePictureContentType = profilePicture.ContentType; // Store content type
                    }
                }

                _context.Add(course); // Add new course to the database
                await _context.SaveChangesAsync(); // Save the changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the courses index page
            }
            return View(course); // Return the same view in case of errors
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ShortDescription,LongDescription,Author,Price,Duration,ProfilePicture,ProfilePictureFileName,ProfilePictureContentType")] Course course, IFormFile profilePicture)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // If a new profile picture is uploaded, update it
                    if (profilePicture != null && profilePicture.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await profilePicture.CopyToAsync(memoryStream);
                            course.ProfilePicture = memoryStream.ToArray();
                            course.ProfilePictureFileName = profilePicture.FileName;
                            course.ProfilePictureContentType = profilePicture.ContentType;
                        }
                    }

                    _context.Update(course); // Update the existing course in the database
                    await _context.SaveChangesAsync(); // Save the changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the courses index page
            }
            return View(course); // Return the same view in case of errors
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course); // Remove the course from the database
            }

            await _context.SaveChangesAsync(); // Save the changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the courses index page
        }

        private bool CourseExists(Guid id)
        {
            return _context.Course.Any(e => e.Id == id); // Check if the course exists in the database
        }

        // This action is used to serve the profile picture image.
        public IActionResult GetProfilePicture(Guid id)
        {
            var course = _context.Course.FirstOrDefault(c => c.Id == id);
            if (course?.ProfilePicture == null)
            {
                return NotFound();
            }
            return File(course.ProfilePicture, course.ProfilePictureContentType); // Return the image with the correct content type
        }
    }
}
