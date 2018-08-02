using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieDetails.Models
{
    public class Actor
    {
        public int ActorID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActorName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActorSex { get; set; }

        [Required]
        public string ActorBio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ActorDOB { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}