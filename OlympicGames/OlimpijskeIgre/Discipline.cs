using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpijskeIgre
{
    public class Discipline
    {
        string _sport;
        string _disciplineName;
        readonly List<Result> _listOfResults;

        public Discipline(string sport, string disciplineName)
        {
            _sport = sport;
            this._disciplineName = disciplineName;
            _listOfResults = new List<Result>();
        }

        public List<Result> ListOfResults { get { return _listOfResults; } }

        public string DisciplineName { get { return _disciplineName; } }

        public string Sport { get { return _sport; } }

        public string Show()
        {
            string result = $"Sport: {_sport}, discipline: {_disciplineName}"+Environment.NewLine;
            result += $"\t List of results:" + Environment.NewLine + Environment.NewLine;
            foreach (Result r in _listOfResults)
            {
                result += r.Show() + Environment.NewLine;
            }
            return result;
        }

        public string ShowMedalWinners()
        {
            string result = $"Sport: {_sport}, discipline: {_disciplineName}" + Environment.NewLine;
            result += $"\t List of results:" + Environment.NewLine + Environment.NewLine;
            foreach (Result r in _listOfResults)
            {
                if(r.Medal!=Medals.NoMedal)
                   result += r.Show() + Environment.NewLine;
            }
            return result;
        }
    }
}
