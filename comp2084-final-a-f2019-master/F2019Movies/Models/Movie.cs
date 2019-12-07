using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F2019Movies.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? Revenue { get; set; }
        public int StudioId { get; set; }
        [StringLength(100)]
        public string Poster { get; set; }

        [ForeignKey("StudioId")]
        [InverseProperty("Movie")]
        public virtual Studio Studio { get; set; }
    }
}
