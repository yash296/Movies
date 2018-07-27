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
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public DateTime MovieRelease { get; set; }
        public virtual Actor Actors { get; set; }
        public virtual Producer Producers { get; set; }
    }
}