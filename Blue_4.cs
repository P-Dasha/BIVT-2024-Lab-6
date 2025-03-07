using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            // поля
            private string _name;
            private int[] _scores;

            // свойства
            public string Name { get { return _name; } }
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;

                    int[] copy = new int[_scores.Length];
                    for (int i = 0; i < copy.Length; i++)
                        copy[i] = _scores[i];

                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    return _scores.Sum();
                }
            }

            // конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            // методы
            public void PlayMatch(int result)
            {
                if (_scores == null) return;

                int[] newscores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                    newscores[i] = _scores[i];

                newscores[newscores.Length - 1] = result;
                _scores = newscores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }
        }

        public struct Group
        {
            // поля
            private string _name;
            private Team[] _teams;
            private int _count;

            // свойства
            public string Name { get { return _name; } }
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;
                    return _teams;
                }
            }

            // конструктор
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            // методы
            public void Add(Team team)
            {
                if (_teams == null) return;

                if (_count < _teams.Length)
                {
                    _teams[_count] = team;
                    _count++;
                }
            }

            public void Add(Team[] teams)
            {
                if (_teams == null || teams.Length == 0 || teams == null) return;
                foreach (var team in teams)
                {
                    Add(team);
                }
            }

            // по убыванию
            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;

                for (int i = 0; i < _teams.Length; i++)
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);

            }

            // слияние двух отсортированных массивов команд двух групп в новую группу с ограничением по размеру
            public static Group Merge(Group group1, Group group2, int size)
            {
                if (group1.Teams == null || group2.Teams == null || size <= 0) return default(Group);

                Group result = new Group("Финалисты");
                int index1 = 0, index2 = 0;

                while (index1 < size / 2 && index2 < size / 2)
                {
                    if (group1.Teams[index1].TotalScore >= group2.Teams[index2].TotalScore)
                    {
                        result.Add(group1.Teams[index1]);
                        index1++;
                    }
                    else
                    {
                        result.Add(group2.Teams[index2]);
                        index2++;
                    }
                }

                while (index1 < size / 2)
                    result.Add(group1.Teams[index1++]);

                while (index2 < size / 2)
                    result.Add(group2.Teams[index2++]);

                return result;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (Team p in _teams)
                    p.Print();

                Console.WriteLine();
            }
        }
    }
}
