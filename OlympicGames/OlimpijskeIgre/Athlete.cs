using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpijskeIgre
{
    public class Athlete:Person
    {
        string CountryPLaysFor;

        public Athlete(string name, DateTime dateOfBirth, string BirthCountry, string countryplaysFor)
            :base(name, dateOfBirth, BirthCountry)
        {
            CountryPLaysFor = countryplaysFor;
        }

        public string CountryPlaysFor { get { return CountryPLaysFor; } }

        public new string Show()
        {
            return $"Athlete: {base.Show()}, \nCountry for which he compets: {CountryPLaysFor}";
        }

        public override bool Equals(object obj)
        {
            if ((obj as Athlete).CountryPLaysFor == CountryPLaysFor && (obj as Athlete).Name == _name
                && (obj as Athlete)._dateOfBirth == _dateOfBirth && (obj as Athlete)._birthCountry == _birthCountry)
                return true;

            return false;
        }
    }
}
