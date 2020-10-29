using BLL.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class CreateMovieVM
    {
        public CreatemovieDTO MovieModel { get; set; }
        public CreateMovieComponents Components { get; set; }
    }
}
