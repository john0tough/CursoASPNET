using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }
        public IEnumerable<Genre> Genre { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            this.Name = movie.Name;
            this.GenreId = movie.GenreId;
            this.ReleaseDate = movie.ReleaseDate;
            this.NumberInStock = movie.NumberInStock;
        }
    }
}