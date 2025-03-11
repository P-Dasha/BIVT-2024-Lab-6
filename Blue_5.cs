using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            // поля
            private string _name;
            private string _surname;
            private int _place;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Place { get { return _place; } }

            // конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            // методы
            public void SetPlace(int place)
            {
                if (_place != 0 ) return;
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_place}");
            }
        }

        public struct Team
        {
            // поля
            private string _name;
            private Sportsman[] _sportsmen;
            private int _sportsmenPlace;

            // свойства
            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen { get { return _sportsmen; } }
            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;

                    int sum = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        switch (_sportsmen[i].Place)
                        {
                            case 1: sum += 5; break;
                            case 2: sum += 4; break;
                            case 3: sum += 3; break;
                            case 4: sum += 2; break;
                            case 5: sum += 1; break;
                            default: break;
                        }
                    }
                    return sum;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int top = _sportsmen[0].Place;
                    for (int i = 1; i < _sportsmen.Length; i++)
                    {
                        if (top > _sportsmen[i].Place)
                            top = _sportsmen[i].Place;
                    }

                    return top;
                }
            }

            // конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _sportsmenPlace = 0;
            }

            // методы
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null)
                    _sportsmen = new Sportsman[6];

                if (_sportsmenPlace < 6)
                    _sportsmen[_sportsmenPlace++] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || sportsmen == null || sportsmen.Length == 0 || _sportsmenPlace >= _sportsmen.Length) return;

                foreach (var sportsman in sportsmen)
                    Add(sportsman);
                
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                for (int i = 0; i < teams.Length - 1; i++)
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);

                        else if (teams[j + 1].SummaryScore == teams[j].SummaryScore && teams[j + 1].TopPlace < teams[j].TopPlace)
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);

                    }
            }

            public void Print()
            {
                
                Console.WriteLine($"Команда: {_name}");
                Console.WriteLine($"Суммарный балл: {SummaryScore}");
                Console.WriteLine($"Наивысшее место: {TopPlace}");
                Console.WriteLine("Спортсмены:");

                if (_sportsmen != null && _sportsmen.Length > 0)
                {
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        _sportsmen[i].Print();
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о спортсменах.");
                }
                Console.WriteLine();

            }
        }
    }
}
