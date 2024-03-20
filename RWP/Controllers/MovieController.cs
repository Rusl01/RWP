using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWP.Data;
using RWP.Models;
using RWP.Service;

namespace RWP.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        private readonly IMovieService movieService;

        public MovieController(IMovieService _service)
        {
            movieService = _service;
        }

        public async Task<IActionResult> Index()
        {
            var fd = await movieService.Get();
            return View(await movieService.Get());
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            return View(await movieService.Get(id));
        }

        // GET: MovieController/Create
        public ActionResult Create() => View();

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection, Movie movie)
        {
            try
            {
                await movieService.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public async Task<ActionResult> Edit(int id) => View(await movieService.Get(id));

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(IFormCollection collection, Movie movie)
        {
            try
            {
                await movieService.Edit(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id) => View(await movieService.Get(id));

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                await movieService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
