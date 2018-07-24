using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDetails.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
        public string Bio{ get; set; }
        public DateTime ProducerDob { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }
    }
}