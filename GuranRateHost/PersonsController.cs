using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GuranRateHost
{
    // Person class defines a Person object
    // Last Name, First Name, Gender, Favorite Color, and Date of Birth and Sortable Birth date index
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime DateOfBirthIndex { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonsController : ApiController
    {
        static bool personFilled;
        static List<Person> persons = fillPersons();
        
        // This is the Default View... when a person types 
        // host/Persons, this is the data in order of entry
        // example: //localhost/Persons
        public IEnumerable<Person> Get()
        {
            return (persons);
        }

        // This is the overloaded method GET, where the ID is actually
        // the Sort Key, Name(Last Name, First), Gender, or Date of Birth
        // host/Persons/{id} = example: "//localhost/Persons/Gender for sort by Gender
        public IEnumerable<Person> Get(string id)
        {
            // Sort Persons data by Gender
            if (id == "Gender")
            {
                var sorted = persons.OrderBy(g => g.Gender).ThenBy(l => l.LastName);
                return sorted;
            }

            // Sort Persons data by Date of Birth
            if (id == "BirthDate")
            {
                var sorted = persons.OrderBy(b => b.DateOfBirthIndex);
                return sorted;
            }

            // Sort Persons data by Last name then first name
            if (id == "Name")
            {
                var sorted = persons.OrderByDescending(n => n.LastName).ThenBy(n => n.FirstName);
                return sorted;
            }

            return null;
        }
        
        // Post a new Record to the data base
        // host/Persons = example using a POST command : //localhost/Persons
        public void Post([FromBody] Person value)
        {
            Person postPer = new Person();
            postPer.LastName = value.LastName;
            postPer.FirstName = value.FirstName;
            postPer.Gender = value.Gender;
            postPer.FavoriteColor = value.FavoriteColor;
            var bd = Convert.ToDateTime(value.DateOfBirth).ToShortDateString();
            postPer.DateOfBirth = bd;
            postPer.DateOfBirthIndex = Convert.ToDateTime(value.DateOfBirth);
            persons.Add(postPer);
            personFilled = true; 
             
        }
    
       // This Method will be called initially to load the data structure, which is 
       // a LIST collection. It is temporary and will only be persisted while the server is
       // running. Once the server is stopped or terminated, the data will be erased
       // This method has no input parameters, it finds 3 database text files all formatted
       // differently. It will read the data from the files and parce out the data and 
       // create the Person object, which will be stored in the LIST<Person>
       public static List<Person> fillPersons()
        {
            
            List<Person> newPerson = new List<Person>();
            List<string> files = new List<string>();
            files.Add("dataInput1.txt");
            files.Add("dataInput2.txt");
            files.Add("dataInput3.txt");
            if (!personFilled)
            {
                foreach (var file in files)
                {
                    var fileStream = new FileStream(@"c:\" + file, FileMode.Open, FileAccess.Read);
                    string line;

                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            // Break the line up into smaller components
                            string[] elements = line.Split('|');
                            string[] elements2 = line.Split(',');
                            string[] elements3 = line.Split(' ');
                            string[] values = new string[5];
                            string LastName = "";
                            string FirstName = "";
                            string Gender = "";
                            string FavoriteColor = "";
                            string DateOfBirth = "";

                            // Figure out what type of separator the line is and parce it out 
                            if (elements.Length > 1)
                                values = elements;
                            if (elements2.Length > 1)
                                values = elements2;
                            if (elements3.Length > 1)
                                values = elements3;

                            int ele = 1;
                            foreach (var element in values)
                            {
                                if (ele == 1)
                                    LastName = element;
                                if (ele == 2)
                                    FirstName = element;
                                if (ele == 3)
                                    Gender = element;
                                if (ele == 4)
                                    FavoriteColor = element;
                                if (ele == 5)
                                    DateOfBirth = element;

                                ele++;
                            }
                             
                            Person per = new Person();
                            per.LastName = LastName;
                            per.FirstName = FirstName;
                            per.Gender = Gender;
                            per.FavoriteColor = FavoriteColor;
                            var bd = Convert.ToDateTime(DateOfBirth).ToShortDateString(); 
                            per.DateOfBirth = bd;
                            per.DateOfBirthIndex = Convert.ToDateTime(DateOfBirth);
                            newPerson.Add(per);
                        }
                    }
                }

                return newPerson;
            } else
            {
                return persons;
            }
        } 
    }


}
