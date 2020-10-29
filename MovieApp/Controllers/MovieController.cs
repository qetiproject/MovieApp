using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieOperation movieOperation;
        public MovieController(IMovieOperation movieOperation)
        {
            this.movieOperation = movieOperation;
        }
        public IActionResult Index()
        {
            var model = movieOperation.GetAll();
            return View(model) ;
        }

        public IActionResult Create()
        {
            CreateMovieVM model = new CreateMovieVM();
            model.Components = movieOperation.GetCreateMovieComponents();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateMovieVM model)
        {
            if(!ModelState.IsValid)
            {
                model.Components = movieOperation.GetCreateMovieComponents();
                return View(model);
            }

            movieOperation.Create(model.MovieModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            EditMovieVM model = new EditMovieVM();
            model.Components = movieOperation.GetCreateMovieComponents();
            model.MovieModel = movieOperation.GetEditMovieData(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditMovieVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            movieOperation.Edit(model.MovieModel);
            return RedirectToAction(nameof(Edit), new { id = model.MovieModel.Id });
        }
    }
}