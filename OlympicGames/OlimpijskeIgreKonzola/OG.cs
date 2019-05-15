using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlimpijskeIgre;

namespace OlimpijskeIgreKonzola
{
    class OG
    {
        string _year;
        string _location;
        List<Discipline> _listOfDisciplines;

        public OG(string year, string location)
        {
            _year = year;
            _location = location;
            _listOfDisciplines = new List<Discipline>();
        }

        public string Show()
        {
            string result = $"Year: {_year}, location: {_location}" + Environment.NewLine;
            result += "List of disciplines: " + Environment.NewLine + Environment.NewLine;
            foreach (Discipline discipline in _listOfDisciplines)
            {
                result += $"\t{discipline.Show()} "+Environment.NewLine;
            }
            return result;
        }

        public int TotalAMountOfMedals(Athlete athlete)
        {
            int counter = 0;
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.Equals(athlete) && r.Medal != Medals.NoMedal)
                        counter++;

            return counter;   
        }

        public List<string> DisciplineNames(string country)
        {
            List<string> list = new List<string>();
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.CountryPlaysFor == country && !list.Contains(discipline.DisciplineName))
                        list.Add(discipline.DisciplineName);

            return list;
        }

        public int TotalNumberOfSports()
        {
            List<string> sports = new List<string>();
            foreach (Discipline discipline in _listOfDisciplines)
                if (!sports.Contains(discipline.Sport))
                    sports.Add(discipline.Sport);

            return sports.Count;
        }

        public bool WonMedal(Athlete athlete, string sport)
        {
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.Equals(athlete) && discipline.Sport==sport &&
                        (r.Medal == Medals.Gold || r.Medal == Medals.Silver))
                        return true;

            return false;
        }

        public string CountryWithYoungestAthlete()
        {
            int youngest = int.MaxValue;
            string result = "";

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if ((DateTime.Now - r.Athlete.DateOfBirth).Days < youngest)
                    {
                        youngest = (DateTime.Now - r.Athlete.DateOfBirth).Days;
                        result = r.Athlete.CountryPlaysFor;
                    }

            return result;
        }

        public string CountryWIthMostAthlets()
        {
            Dictionary<string, int> countries = new Dictionary<string, int>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (!countries.Keys.Contains(r.Athlete.CountryPlaysFor))
                        countries.Add(r.Athlete.CountryPlaysFor, 1);
                    else
                        countries[r.Athlete.CountryPlaysFor]++;

            int bigestNumber = -1;

            List<int> values = countries.Values.ToList();
            List<string> keys = countries.Keys.ToList();

            string result = "";

           
            for (int i = 0; i < keys.Count; i++)
            {
                if (values[i] > bigestNumber)
                {
                    bigestNumber = values[i];
                    result = keys[i];
                }
            }
            return result;
        }

        public List<string> CountryThatStartsWithLetter(char letter)
        {
            List<string> countries = new List<string>();
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.CountryPlaysFor[0] == letter &&
                        !countries.Contains(r.Athlete.CountryPlaysFor))
                        countries.Add(r.Athlete.CountryPlaysFor);

            return countries;
                        
        }

        public List<string> AthletesNotBornInCountryTheyCompeteFor()
        {
            List<string> names = new List<string>();
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.BirthCountry != r.Athlete.CountryPlaysFor
                        && !names.Contains(r.Athlete.Name))
                        names.Add(r.Athlete.Name);

            return names;
        }

        public bool MedalWonOnBirthday()
        {
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Medal != Medals.NoMedal && r.Athlete.DateOfBirth.Month == DateTime.Now.Month
                        && r.Athlete.DateOfBirth.Day == DateTime.Now.Day)
                        return true;

            return false;
        }

        public int AmountOfMEdalsWonByHost()
        {
            int counter = 0;
            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.CountryPlaysFor == _location.Split('/')[1]
                        && r.Medal != Medals.NoMedal)
                        counter++;

            return counter;
        }

        public int NumberOfAthletesForCertainGender(string gender)
        {
            int counter = 0;
            foreach (Discipline discipline in _listOfDisciplines)
                if (discipline.DisciplineName.Split('(', ')')[1] == gender)
                        counter += discipline.ListOfResults.Count;

            return counter;
        }

        public List<string> DisciplinesWithMoreThanTwoThirdsUnder25()
        {
            List<string> disciplines = new List<string>();
            int counter;

            foreach (Discipline discipline in _listOfDisciplines)
            {
                counter = 0;
                foreach (Result r in discipline.ListOfResults)
                {
                    int age = (DateTime.Now.Year - r.Athlete.DateOfBirth.Year);
                    if (DateTime.Now.Month < r.Athlete.DateOfBirth.Month ||
                        (DateTime.Now.Month <= r.Athlete.DateOfBirth.Month &&
                        DateTime.Now.Day < r.Athlete.DateOfBirth.Day))
                        age--;

                    if (age < 25)
                        counter++;
                }

                if (counter > ((discipline.ListOfResults.Count / 3) * 2))
                    disciplines.Add(discipline.DisciplineName);
            }

            return disciplines;
        }

        public List<string> CountriesWithoutMedals()
        {
            List<string> countriesWithMedals = new List<string>();
            List<string> allCountries = new List<string>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                {
                    if (!allCountries.Contains(r.Athlete.CountryPlaysFor))
                        allCountries.Add(r.Athlete.CountryPlaysFor);

                    if (r.Medal != Medals.NoMedal &&
                   !countriesWithMedals.Contains(r.Athlete.CountryPlaysFor))
                        countriesWithMedals.Add(r.Athlete.CountryPlaysFor);
                }

            List<string> countriesWithoutMedals = allCountries.Except(countriesWithMedals).ToList();

            return countriesWithoutMedals;
        }

        public List<string> CountriesWithoutAthletesInGivenDiscipline(string givenDiscipline)
        {
            List<string> allCountries = new List<string>();
            List<string> countriesWIthAthletes = new List<string>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    {
                        if (!allCountries.Contains(r.Athlete.CountryPlaysFor))
                            allCountries.Add(r.Athlete.CountryPlaysFor);

                        if (discipline.DisciplineName == givenDiscipline &&
                        !countriesWIthAthletes.Contains(r.Athlete.CountryPlaysFor))
                            countriesWIthAthletes.Add(r.Athlete.CountryPlaysFor);
                    }

            List<string> countriesWIthoutAthletes = allCountries.Except(countriesWIthAthletes).ToList();
            return countriesWIthoutAthletes;
        }

        public int[] AmountOfMEdalsFromGivenDisciplines(params string[] disciplines)
        {
            int[] counter = new int[disciplines.Length];

            for (int i = 0; i < disciplines.Length; i++)
            {
                foreach (Discipline discipline in _listOfDisciplines)
                    foreach (Result r in discipline.ListOfResults)
                        if (discipline.DisciplineName == disciplines[i] && r.Medal != Medals.NoMedal)
                            counter[i]++;
            }

            return counter;
        }

        public List<string> CountriesWithAthletesInAllDisciplines()
        {
            List<string> notCorrectCountries = new List<string>();
            List<string> allCountries = new List<string>();
            foreach (Discipline discipline in _listOfDisciplines)
            {
               List<string>countriesWithout = CountriesWithoutAthletesInGivenDiscipline(discipline.DisciplineName);
                notCorrectCountries = notCorrectCountries.Union(countriesWithout).ToList();

                foreach (Result r in discipline.ListOfResults)
                    if (!allCountries.Contains(r.Athlete.CountryPlaysFor))
                        allCountries.Add(r.Athlete.CountryPlaysFor);
            }

            List<string> countriesInALlDisciplines = allCountries.Except(notCorrectCountries).ToList();
            return countriesInALlDisciplines;
        }

        public string AthleteSuccess(Athlete athlete)
        {
            int numberOfMedals = TotalAMountOfMedals(athlete);
            int numberOfDisciplines = 0;

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                    if (r.Athlete.Equals(athlete))
                    {
                        numberOfDisciplines++;
                        break;
                    }

            return $"{numberOfMedals}/{numberOfDisciplines}";
        }

        public List<string> MedalWinnerInAllDisciplinesCompetedIn()
        {
            List<string> athleteNames = new List<string>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                {
                    string success = AthleteSuccess(r.Athlete);
                    if (success.Split('/')[0] == success.Split('/')[1] && 
                        !athleteNames.Contains(r.Athlete.Name))
                        athleteNames.Add(r.Athlete.Name);
                }

            return athleteNames;
        }

        public string CountryWithHigestPercentageOfMEdals()
        {
            Dictionary<string, double> medalsAndCountries = new Dictionary<string, double>();
            Dictionary<string, double> numberOfAthletes = new Dictionary<string, double>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (Result r in discipline.ListOfResults)
                {
                    if (!medalsAndCountries.Keys.Contains(r.Athlete.CountryPlaysFor))
                    {
                        if (r.Medal == Medals.NoMedal)
                            medalsAndCountries.Add(r.Athlete.CountryPlaysFor, 0);
                        else
                            medalsAndCountries.Add(r.Athlete.CountryPlaysFor, 1);
                    }
                    else
                    {
                        if (r.Medal != Medals.NoMedal)
                            medalsAndCountries[r.Athlete.CountryPlaysFor]++;
                    }

                    if (!numberOfAthletes.Keys.Contains(r.Athlete.CountryPlaysFor))
                        numberOfAthletes.Add(r.Athlete.CountryPlaysFor, 1);
                    else
                        numberOfAthletes[r.Athlete.CountryPlaysFor]++;
                }

            List<double> percentage = new List<double>();
            List<double> amountOfMedals=medalsAndCountries.Values.ToList();
            List<double> amountOfAthletes = numberOfAthletes.Values.ToList();

            for (int i = 0; i < amountOfMedals.Count; i++)
            {
                percentage.Add((amountOfMedals[i] / amountOfAthletes[i]) * 100);
            }

            double biggestPercentage = -1;
            List<string> countries = medalsAndCountries.Keys.ToList();
            string country = "";

            for (int i = 0; i < percentage.Count; i++)
            {
                if (percentage[i] > biggestPercentage)
                {
                    biggestPercentage = percentage[i];
                    country = countries[i];
                }
            }

            return country;
        }

        public Athlete AthletesWithTheMostGoldMedals(params string[] sports)
        {
            Dictionary<Athlete, int> goldMedals = new Dictionary<Athlete, int>();

            foreach (Discipline discipline in _listOfDisciplines)
                foreach (string sport in sports)
                    if (discipline.Sport == sport)
                        foreach (Result r in discipline.ListOfResults)
                        {
                            if (!goldMedals.Keys.Contains(r.Athlete) && r.Medal == Medals.Gold)
                                goldMedals.Add(r.Athlete,1);
                            else if(goldMedals.Keys.Contains(r.Athlete) && r.Medal == Medals.Gold)
                                goldMedals[r.Athlete]++;
                        }

            List<Athlete> athletes = goldMedals.Keys.ToList();
            List<int> numberOfGoldMedals = goldMedals.Values.ToList();

            int mostMedals = -1;
            int position = -1;


            for (int i=0;i<numberOfGoldMedals.Count;i++)
            {
                if (numberOfGoldMedals[i] > mostMedals)
                {
                    mostMedals = numberOfGoldMedals[i];
                    position = i;
                }
            }

            return athletes[position];

        }

        public string ShowMedalWinners()
        {
            string result = $"Year: {_year}, location: {_location}" + Environment.NewLine;
            result += "List of disciplines and medal winners: " + Environment.NewLine + Environment.NewLine;
            foreach (Discipline discipline in _listOfDisciplines)
            {
                result += $"\t{discipline.ShowMedalWinners()} " + Environment.NewLine;
            }
            return result;
        }

        static void Main(string[] args)
        {
            OG olimpic = new OG("2018", "Beograd/Srbija");
            Athlete s1 = new Athlete("Milan Popovic", new DateTime(1990,5,5), "Serbia", "Serbia");
            Athlete s2 = new Athlete("Jelena Markovic", new DateTime(1999, 3, 3), "Serbia", "Serbia");
            Athlete s3 = new Athlete("Amir Hadzic", new DateTime(1998, 1, 13), "France", "France");
            Athlete s4 = new Athlete("Hrvoje Pantic", new DateTime(2002, 2, 15), "UK", "Serbia");
            Athlete s5 = new Athlete("Mitar Miljus", new DateTime(2000, 4, 23), "Belgium", "Serbia");


            Result r1 = new Result(s1, "Second", Medals.Silver);
            Result r2 = new Result(s2, "Second", Medals.Silver);
            Result r3 = new Result(s3, "Sixth", Medals.NoMedal);
            Result r4 = new Result(s4, "First", Medals.NoMedal);
            Result r5 = new Result(s5, "Third", Medals.Bronze);


            Discipline d1 = new Discipline("Athletic", "100m(Men)");
            d1.ListOfResults.Add(r1);
            d1.ListOfResults.Add(r3);
            d1.ListOfResults.Add(r4);
            d1.ListOfResults.Add(r5);

            Discipline d2 = new Discipline("Athletic", "100m(Women)");
            d2.ListOfResults.Add(r2);

            Discipline d3 = new Discipline("Athletic", "200m(Men)");
            Result r6 = new Result(s1, "Fifth", Medals.NoMedal);
            Result r7 = new Result(s4, "First", Medals.Gold);
            d3.ListOfResults.Add(r6);
            d3.ListOfResults.Add(r7);

            olimpic._listOfDisciplines.Add(d1);
            olimpic._listOfDisciplines.Add(d2);
            olimpic._listOfDisciplines.Add(d3);

            //Console.WriteLine(olimpic.Show());
            //Console.WriteLine(olimpic.ShowMedalWinners());


            //1.Console.WriteLine(olimpic.TotalAMountOfMedals(s1));
            //2.List<string> disciplineNames = olimpic.DisciplineNames("Serbia");
            //foreach (string item in disciplineNames)
            //{
            //    Console.WriteLine(item);
            //}

            //3.Console.WriteLine(olimpic.TotalNumberOfSports());
            //4.Console.WriteLine(olimpic.WonMedal(s1, "Athletic"));
            //5.Console.WriteLine(olimpic.CountryWithYoungestAthlete());
            //6.Console.WriteLine(olimpic.CountryWIthMostAthlets());

            //7.List<string> countryOnALetter = olimpic.CountryThatStartsWithLetter('S');
            //foreach (string a in countryOnALetter)
            //{
            //    Console.WriteLine(a);
            //}

            //8.List<string> notBornInCOuntry = olimpic.AthletesNotBornInCountryTheyCompeteFor();
            //foreach (string a in notBornInCOuntry)
            //{
            //    Console.WriteLine(a);
            //}

            //9.Console.WriteLine(olimpic.MedalWonOnBirthday());
            //10.Console.WriteLine(olimpic.AmountOfMEdalsWonByHost());
            //11.Console.WriteLine(olimpic.NumberOfAthletesForCertainGender("Muskarci"));

            //12.List<string> young = olimpic.DisciplinesWithMoreThanTwoThirdsUnder25();
            //foreach (string a in young)
            //{
            //    Console.WriteLine(a);
            //}

            //13.List<string> withoutMedals = olimpic.CountriesWithoutMedals();
            //foreach (string a in withoutMedals)
            //{
            //    Console.WriteLine(a);
            //}

            //14.List<string> wihtoutAtlhetes = olimpic.CountriesWithoutAthletesInGivenDiscipline("100m(Women)");
            //foreach (string a in wihtoutAtlhetes)
            //{
            //    Console.WriteLine(a);
            //}

            //15. int[] array = olimpic.AmountOfMEdalsFromGivenDisciplines("100m(Men)", "ojsa sa", "100m(Women)");
            //foreach (int a in array)
            //{
            //    Console.WriteLine(a);
            //}

            //16.List<string> countryNames = olimpic.CountriesWithAthletesInAllDisciplines();
            //foreach (string a in countryNames)
            //{
            //    Console.WriteLine(a);
            //}

            //17.Console.WriteLine(olimpic.AthleteSuccess(s4));

            //18.List<string> winners = olimpic.MedalWinnerInAllDisciplinesCompetedIn();
            //foreach (string a in winners)
            //{
            //    Console.WriteLine(a);
            //}

            //19.Console.WriteLine(olimpic.CountryWithHigestPercentageOfMEdals());

            //20.Console.WriteLine(olimpic.AthletesWithTheMostGoldMedals("Basketball", "Football", "Athletic").Name);

            Console.ReadLine();

            

        }
        
    }
}
