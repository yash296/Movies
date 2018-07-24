using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieDetails.Models;

namespace MovieDetails.DAL
{
    public class DetailsInitiallizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DetailsContext>
    {
        protected override void Seed(DetailsContext context)
        {
            var actors = new List<Actor>
            {
                new Actor{ActorID=01 , ActorDOB=DateTime.Parse("1979-08-03"), ActorName = "Evangeline Lilly", ActorBio="Evangeline Lilly, born in Fort Saskatchewan, Alberta in 1979, was discovered on the streets of Kelowna, British Columbia by the famous Ford modeling agency. Although she initially decided to pass on a modeling career, she went ahead and signed with Ford anyway, to help pay for her University of British Columbia tuition and expenses.",ActorSex = "Female"},
                new Actor{ActorID=02 , ActorDOB=DateTime.Parse("1985-04-30"), ActorName = "Gal Gadot", ActorBio="Gal Gadot is an Israeli actress, singer, martial artist, and model. She was born in Rosh Ha'ayin, Israel, to an Ashkenazi Jewish family. Her parents are Irit, a teacher, and Michael, an engineer, who is a sixth-generation Israeli. She served in the IDF for two years, and won the Miss Israel title in 2004. Gal began modeling in the late 2000s" , ActorSex = "Female" },
                new Actor{ActorID=03 , ActorDOB=DateTime.Parse("1972-05-22"), ActorName = "Dwayne Johnson", ActorBio="Dwayne Douglas Johnson, also known as The Rock, was born on May 2, 1972 in Hayward, California. He is the son of Ata Johnson (born Feagaimaleata Fitisemanu Maivia) and professional wrestler Rocky Johnson (born Wayde Douglas Bowles). His father, from Amherst, Nova Scotia, Canada, is black (of Black Nova Scotian descent), and his mother is of Samoan...", ActorSex = "Female" }

            };
            actors.ForEach(s => context.Actors.Add(s));
            context.SaveChanges();
            var producers = new List<Producer>
            {
                new Producer{ProducerDob=DateTime.Parse("1965-04-04"), ProducerID = 01, ProducerName = "Richard Brener", Bio="hbhjadashdoa dkjadkajd dakdnaksdn dadakd"},
                new Producer{ProducerDob=DateTime.Parse("1987-05-06"),ProducerID=02,ProducerName="Tom Holland", Bio="adhadjoiajdoajdoiadasodj asdaddadnaoid dhabdkas "},
                new Producer{ProducerDob=DateTime.Parse("1993-05-06"), ProducerID=03, ProducerName = "Anurag kashyap",Bio="ahdbaduaihdiadha"},
            };
            producers.ForEach(s => context.Producers.Add(s));
            context.SaveChanges();
            var movies = new List<Movie>
            {
                new Movie{MovieID = 01, MovieName = "Jumanji", MovieRelease= DateTime.Parse("2014-07-06"),MoviePlot="ashdakdh dahdkjad jdabdkjad", ActorID = 03 , ProducerID= 01},
                new Movie{MovieID= 02, MovieName = "Wonder Woman", MovieRelease=DateTime.Parse("2018-05-03"), MoviePlot ="adjhahdj oiadjoaijd aojdnoijeroq", ActorID = 02, ProducerID =02},
                new Movie{MovieID = 03, MovieName = "Chef", MovieRelease=DateTime.Parse("2017-05-01"), MoviePlot=" yy y y yy y yyyy abdah dyy yyy y", ActorID = 01, ProducerID =03}
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();


        }
    }
}