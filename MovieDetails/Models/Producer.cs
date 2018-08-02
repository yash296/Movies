using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieDetails.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ProducerName { get; set; }
        public string Bio{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProducerDob { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }
    }
}