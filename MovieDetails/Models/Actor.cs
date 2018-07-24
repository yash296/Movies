using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDetails.Models
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string ActorName { get; set; }
        public string ActorSex { get; set; }
        public string ActorBio { get; set; }
        public DateTime ActorDOB { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}