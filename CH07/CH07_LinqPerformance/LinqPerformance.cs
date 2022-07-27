namespace CH07_LinqPerformance
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LinqPerformance
    {
        private List<Person> _people = new List<Person>();
        private string[] _group1 = new string[] { "iota", "epsilon", "sigma", "upsilon" };
        private string[] _group2 = new string[] { "alpha", "omega" };

        static Action _filterPeople;
        delegate List<Person> FilteredPeople();

        private static List<Person> _filteredPeople;

        [GlobalSetup]
        public void PrepareBenchmarks()
        {
            char firstLetter = 'K';
            char lastLetter = 'T';

            string lastName = "Tau";

            _people.Clear();

            _people.Add(new Person("Alpha", "Beta"));
            _people.Add(new Person("Chi", "Delta"));
            _people.Add(new Person("Epsilon", "Phi"));
            _people.Add(new Person("Gamma", "iota"));
            _people.Add(new Person("Kappa", "Lambda"));
            _people.Add(new Person("Mu", "Nu"));
            _people.Add(new Person("Omicron", "Pi"));
            _people.Add(new Person("Theta", "Rho"));
            _people.Add(new Person("Sigma", "Tau"));
            _people.Add(new Person("Upsilon", "Omega"));
            _people.Add(new Person("Xi", "Psi"));
            _people.Add(new Person("Zeta", "Iota"));
            _people.Add(new Person("Alpha", "Omega"));
            _people.Add(new Person("Omega", "Chi"));
            _people.Add(new Person("Sigma", "Tau"));

            _filterPeople = () =>
            {
                _filteredPeople = _people.Where(p => p.LastName.Between(firstLetter, lastLetter)).ToList();
            };
        }

        [Benchmark]
        public List<Person> FilterGroupsVersion1()
        {
            return (from p in _people
                    where _group1.Contains(p.LastName.ToLower())
                     || _group2.Contains(p.LastName.ToLower())
                    select p).ToList();
        }

        [Benchmark]
        public List<Person> FilterGroupsVersion2()
        {
            return (from p in _people
                    let lastName = p.LastName.ToLower()
                    where _group1.Contains(lastName)
                    || _group2.Contains(lastName)
                    select p).ToList();
        }

        [Benchmark]
        public List<Person> FilterGroupsVersion3()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < _people.Count; i++)
            {
                Person person = _people[i];
                string lastName = person.LastName.ToLower();
                if (
                    _group1.Contains(lastName)
                    || _group2.Contains(lastName)
                )
                    people.Add(person);
            }
            return people;
        }

        [Benchmark]
        public List<Person> FilterGroupsVersion4()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < _people.Count; i++)
            {
                Person person = _people[i];
                string lastName = person.LastName.ToLower();
                if (
                    _group2.Contains(lastName)
                    || _group1.Contains(lastName)
                )
                    people.Add(person);
            }
            return people;
        }

        [Benchmark]
        public void GetLastPersonVersion1()
        {
            Person lastPerson = _people.Last();
        }

        [Benchmark]
        public void GetLastPersonVersion2()
        {
            Person lastPerson = _people[_people.Count - 1];
        }

        [Benchmark]
        public void GetLastPersonVersion3()
        {
            Person lastPerson = _people.LastItem();
        }

        [Benchmark]
        public void GroupByVersion1()
        {
            List<Person> people = _people.GroupBy(x => x.LastName)
                                            .Where(x => x.Count() > 1)
                                            .SelectMany(group => group)
                                            .ToList();
        }

        [Benchmark]
        public void GroupByVersion2()
        {
            IEnumerator<IGrouping<string, Person>> test = _people.GroupBy(p => p.LastName)
            .Where(p => p.Count() > 2).GetEnumerator();
            List<Person> people = new List<Person>();
            while (test.MoveNext())
            {
                IGrouping<string, Person> current = test.Current;
                foreach (Person person in current)
                {
                    people.Add(person);
                }
            }
        }

        [Benchmark]
        public void GroupByVersion3()
        {
            IEnumerator<IGrouping<string, Person>> test = _people.ToArray().GroupBy(p => p.LastName)
            .Where(p => p.Count() > 2).GetEnumerator();
            List<Person> people = new List<Person>();
            while (test.MoveNext())
            {
                var current = test.Current;
                foreach (var person in current)
                {
                    people.Add(person);
                }
            }
        }

        [Benchmark]
        public void GroupByVersion4()
        {
            var result = (from person in _people select person).ToLookup(p => p.LastName);
        }

        [Benchmark]
        public void GroupByVersion5()
        {
            IEnumerator<IGrouping<string, Person>> test = _people.ToHashSet().GroupBy(p => p.LastName)
                .Where(p => p.Count() > 2).GetEnumerator();
            HashSet<Person> people = new HashSet<Person>();
            while (_people.ToHashSet().GroupBy(p => p.LastName)
                .Where(p => p.Count() > 2).GetEnumerator().MoveNext())
            {
                var current = test.Current;
                foreach (var person in current)
                {
                    people.Add(person);
                }
            }
        }

        [Benchmark]
        public void Interface()
        {
            Interface obj = new ConcreteClass();
            obj.Add(new Person());
        }

        [Benchmark]
        public void ConcreteClass()
        {
            ConcreteClass concreteClass = new ConcreteClass();
            concreteClass.Add(new Person());
        }

        [Benchmark]
        public void FindMethod1()
        {
            string surname = "Omega";
            Person person = _people.Where(p => p.LastName.Equals(surname)).FirstOrDefault();
        }

        [Benchmark]
        public void FindMethod2()
        {
            string surname = "Omega";
            Person person = _people.FirstOrDefault(p => p.LastName.Equals(surname));
        }

        [Benchmark]
        public void Closure()
        {
            _filterPeople();
            foreach (Person person in _filteredPeople)
                Console.WriteLine(person.FullName);
        }

        [Benchmark]
        public void Nonclosure()
        {
            foreach (Person person in _people.Where(p =>
                 char.Parse(p.LastName.Substring(0, 1)) >= 'k'
                 && char.Parse(p.LastName.Substring(0, 1)) <= 'T'
            ))
                Console.WriteLine(person.FullName);
        }

        private int x;

        public static void ExecuteAction<T>(T actionObject, Action<T> action)
        {
            action(actionObject);
        }

        public static void ExecuteAction(Action action)
        {
            action();
        }

        [Benchmark]
        public void ExecuteWithParamater()
        {
            int counter = 10;
            ExecuteAction(counter, (ct) =>
            {
                x = ct + 2;
            });
        }

        [Benchmark]
        public void ExecuteWithLocalVariable()
        {
            int counter = 10;
            ExecuteAction(() =>
            {
                x = counter + 2;
            });
        }

        [Benchmark]
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

        [Benchmark]
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

        [Benchmark]
        public void NonLinqFilter()
        {
            var data = _people.FindAll(x => x.LastName[0] >= 'A' && x.LastName[0] <= 'G');
        }

        [Benchmark]
        public void ReadingDataWithoutUsingLet()
        {
            var result = from person in _people
                         where person.LastName.Contains("Omega")
                         && person.FirstName.Equals("Upsilon")
                         select person;
        }

        [Benchmark]
        public void ReadingDataUsingLet()
        {
            var result = from person in _people
                         let lastName = person.LastName.Contains("Omega")
                         let firstName = person.FirstName.Equals("Upsilon")
                         where lastName && firstName
                         select person;
        }
    }
}