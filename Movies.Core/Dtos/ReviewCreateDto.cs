using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Dtos
{
    internal class ReviewCreateDto
    {
        public Guid Id { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string? Comment { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } 
    }
}
