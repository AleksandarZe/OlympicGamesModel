using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpijskeIgre
{
    public class Person
    {
        protected string _name;
        protected DateTime _dateOfBirth;
        protected string _birthCountry;

        public string Name { get { return _name; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } }
        public string BirthCountry { get { return _birthCountry; } }

        public Person(string name, DateTime birthDate, string birthCountry)
        {
            _name = name;
            _dateOfBirth = birthDate;
            _birthCountry = birthCountry;
        }

        public string Show()
        {
            return $"Name: {_name}, Date of birth: {_dateOfBirth.ToShortDateString()}, birth country: {_birthCountry}";
        }
    }
}
