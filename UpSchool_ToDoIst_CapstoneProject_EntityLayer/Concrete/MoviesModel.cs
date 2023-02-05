using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public class MoviesModel
    {
        public class Rootobject
        {
            public Title[] titles { get; set; }

        }

        public class Title
        {

            public Summary summary { get; set; }

            public Jawsummary jawSummary { get; set; }
        }



        public class Summary
        {
            public string type { get; set; }

            [Key]
            public int id { get; set; }
            public bool isOriginal { get; set; }
        }

        public class Jawsummary
        {

            public int id { get; set; }
            public string type { get; set; }

            public string title { get; set; }

            public int releaseYear { get; set; }
            public bool watched { get; set; }
            public string synopsis { get; set; }


            public int seasonCount { get; set; }

            public int episodeCount { get; set; }

            public int runtime { get; set; }
            public string mostLiked { get; set; }
        }




    } }