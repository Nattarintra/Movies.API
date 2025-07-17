using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Dtos
{
    internal class MovieUpdateDto
    {
        [MaxLength(30)]
        [Required(ErrorMessage = "The movie must have a name.")]
        public string Title { get; set; } = null!;

        [Range(1995, 2025)]
        public int Year { get; set; }

        [Range(60, 80)]
        public int Duration { get; set; }
    }
}
