using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_LinqPerformance
{
    internal class ClosureExample
    {
        private List<Person> _people = null;

        public ClosureExample()
        {
            BuildPeopleCollection();
        }

        private void BuildPeopleCollection()
        {
            _people = new()
            {
                new Person("Alpha", "Beta"),
                new Person("Chi", "Delta"),
                new Person("Epsilon", "Phi"),
                new Person("Gamma", "iota"),
                new Person("Kappa", "Lambda"),
                new Person("Mu", "Nu"),
                new Person("Omicron", "Pi"),
                new Person("Theta", "Rho"),
                new Person("Sigma", "Tau"),
                new Person("Upsilon", "Omega"),
                new Person("Xi", "Psi"),
                new Person("Zeta", "Iota"),
                new Person("Alpha", "Omega"),
                new Person("Omega", "Chi"),
                new Person("Sigma", "Tau")
            };
        }

        public void DisplayGreeting()
        {
            var greeting = GetGreeting();
            Console.WriteLine(greeting("Mebsuta"));
        }

        private static Func<string, string> GetGreeting()
        {
            var greeting = "Hello, ";

            Func<string, string> Greeting = delegate (string yourName) {
                return $"{greeting}{yourName}!";
            };

            return Greeting;
        }

        public void LinqClosureUsingParameters()
        {
            Func<string, char, char, bool> Between()
            {
                Func<string, char, char, bool> IsBetween = delegate (string param1, char param2, char param3)
                {
                    var character = param1[0];
                    return ((character >= param2) && (character <= param3));
                };

                return IsBetween;
            }
            var IsBetween = Between();
            var data = (from p in _people.ToList()
                        where IsBetween(p.LastName, 'A', 'G')
                        select p).ToList();
        }

        public void LinqClosureUsingVariables()
        {
            Func<string, bool> Between()
            {
                char first = 'A';
                char last = 'G';
                Func<string, bool> IsBetweenAG = delegate (string param1)
                {
                    var character = param1[0];
                    return ((character >= first) && (character <= last));
                };

                return IsBetweenAG;
            }
            var IsBetweenAG = Between();
            var data = (from p in _people.ToList()
                        where IsBetweenAG(p.LastName)
                        select p).ToList();
        }
    }
}
