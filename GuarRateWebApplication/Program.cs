using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web.Http;


namespace GuarRateWebApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Files Loading ...");
            List<Person> newPerson = new List<Person>();
            // Parce out input files
            if (args.Length != 0)
            {
                for (int x = 0; x < args.Length; x++)
                {
                    var fileStream = new FileStream(@"c:\" + args[x], FileMode.Open, FileAccess.Read);
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

                            Person per = new GuarRateWebApplication.Person();
                            per.LastName = LastName;
                            per.FirstName = FirstName;
                            per.Gender = Gender;
                            per.FavoriteColor = FavoriteColor;
                            per.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                            newPerson.Add(per);
                        }
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine("Continue to Print ...");
            Console.Read();

            // Sort by Gender, and Last Name Ascending
            var sortPerson = newPerson.OrderBy(s => s.Gender).ThenBy(s => s.LastName);
            Console.WriteLine();
            Console.WriteLine("Order by Gender and Last Name in Ascending Order");
            Console.WriteLine();
            foreach (var p in sortPerson)
            {
                Console.Write(p.LastName + " ");
                Console.Write(p.FirstName + " ");
                Console.Write(p.Gender + " ");
                Console.Write(p.FavoriteColor + " ");
                Console.Write(p.DateOfBirth);
                Console.WriteLine();
            }
            Console.Read(); 

            // Sort by Date of Birth
            var sortPerson2 = newPerson.OrderBy(s => s.DateOfBirth);
            Console.WriteLine();
            Console.WriteLine("Order by Date Of Birth");
            Console.WriteLine();
            foreach (var p in sortPerson2)
            {
                Console.Write(p.LastName + " ");
                Console.Write(p.FirstName + " ");
                Console.Write(p.Gender + " ");
                Console.Write(p.FavoriteColor + " ");
                Console.Write(p.DateOfBirth);
                Console.WriteLine();
            }
             

            // Sort by LastName Descending Order
            var sortPerson3 = newPerson.OrderByDescending(s => s.LastName);
            Console.WriteLine();
            Console.WriteLine("Order by Last Name in Descending Order");
            Console.WriteLine();
            foreach (var p in sortPerson3)
            {
                Console.Write(p.LastName + " ");
                Console.Write(p.FirstName + " ");
                Console.Write(p.Gender + " ");
                Console.Write(p.FavoriteColor + " ");
                Console.Write(p.DateOfBirth);
                Console.WriteLine();
                 
            }
            Console.WriteLine();
            Console.WriteLine("Continue ..."); 
            Console.Read();
        }
          
    }

    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
