using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Collections;


namespace SelfHost
{
    public class PeopleController : ApiController 
    {

        List<Person> persons = BuildPersons();


        public IEnumerable<Person> GetAllPersons()
        {
            return persons;
        }

        public static List<Person> BuildPersons()
        {
            List<Person> newPerson = new List<Person>();
            var fileStream = new FileStream(@"c:\Output\Outfile.txt", FileMode.Open, FileAccess.Read);
            string line;

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Break the line up into smaller components
                    string[] elements = line.Split(',');
                    string[] values = new string[5];
                    string LastName = "";
                    string FirstName = "";
                    string Gender = "";
                    string FavoriteColor = "";
                    string DateOfBirth = "";

                    // Figure out what type of separator the line is and parce it out 
                    if (elements.Length > 1)
                        values = elements;

                    int x = 1;
                    foreach (var element in values)
                    {
                        if (x == 1)
                            LastName = element;
                        if (x == 2)
                            FirstName = element;
                        if (x == 3)
                            Gender = element;
                        if (x == 4)
                            FavoriteColor = element;
                        if (x == 5)
                            DateOfBirth = element;

                        x++;
                    }

                    Person per = new SelfHost.Person();
                    per.LastName = LastName;
                    per.FirstName = FirstName;
                    per.Gender = Gender;
                    per.FavoriteColor = FavoriteColor;
                    per.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                    // write a record to datafile
                    newPerson.Add(per);
                }
            }
            return newPerson;
        } 

    }
}
