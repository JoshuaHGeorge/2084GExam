using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F2019Movies.Models
{
    public partial class Studio
    {
        public Studio()
        {
            Movie = new HashSet<Movie>();
        }

        public int StudioId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Studio")]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
