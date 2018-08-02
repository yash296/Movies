using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieDetails.Models
{
    public class Movie
    {
        public int ActorID { get; set; }
        public int ProducerID { get; set; }
        public int MovieID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string MovieName { get; set; }
        [Required]
        public string MoviePlot { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime MovieRelease { get; set; }
        public virtual Actor Actors { get; set; }
        public virtual Producer Producers { get; set; }
    }
}