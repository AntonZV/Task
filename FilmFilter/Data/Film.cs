using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Data;

namespace FilmFilter.Data
{
    public class director
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public ushort birth_date { get; set; }

        public string info
        {
            get { return String.Format("{0} {1}, {2}", first_name, last_name, birth_date); }
        }
    }
    public class actor
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public ushort birth_date { get; set; }
        public string role { get; set; }
        public string info
        {
            get { return String.Format("{0} {1}, {2}", first_name, last_name, birth_date); }
        }
    }
    public class movie
    {
        public string title { get; set; }
        public ushort year { get; set; }
        public string country { get; set; }
        public string genre { get; set; }
        public string summary { get; set; }

        [XmlElement("director")]
        public director director { get; set; }
        
        [XmlElement("actor")]
        public actor[] actors { get; set; }

        public string actorsAll
        {
            get 
            {
                StringBuilder result = new StringBuilder();
                foreach(var actor in actors)
                {
                    string actorInfo=String.Format("{0} as {1}",actor.info,actor.role);
                    result.AppendLine(actorInfo);
                }
                return result.ToString();
            }
        }
    }

    [XmlRootAttribute("movies")]
    public class movieCollection
    {
        [XmlElement("movie")]
        public movie[] movies { get; set; }
        public static movie[] GetMovies()
        {
            using (TextReader reader = new StreamReader("movies.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(movieCollection));
                movieCollection allMovies = (movieCollection)serializer.Deserialize(reader);
                return allMovies.movies;
            }
            //return;
        }
    }
}
