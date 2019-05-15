using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpijskeIgre
{
    public class Result
    {
        Athlete _athlete;
        string _rank;
        Medals _medal;

        public Result(Athlete athlete, string rank, Medals medal)
        {
            _athlete = athlete;
            _rank = rank;
            _medal = medal;
        }

        public Athlete Athlete { get { return _athlete; } }
        public Medals Medal { get { return _medal; } }

        public string Show()
        {
            return $"{_athlete.Show()}, rank: {_rank}, medal won: {_medal}"+Environment.NewLine;
        }


    }

    public enum Medals
    {
        Gold,
        Silver,
        Bronze,
        NoMedal
    }
}
