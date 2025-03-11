using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _jumpcnt;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;

                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                        for (int j = 0; j < _marks.GetLength(1); j++)
                            copy[i, j] = _marks[i, j];

                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return 0;

                    int total = 0;
                    foreach (var mark in _marks)
                        total += mark;

                    return total;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumpcnt = 0;
            }

            // методы
            public void Jump(int[] result)
            {
                if (result == null || result.Length == 0 || _marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0 || _jumpcnt >= 2) return;

                for (int j = 0; j < 5; j++)
                {
                    _marks[_jumpcnt, j] = result[j];
                }
                _jumpcnt++;
            }

            // сортировка по убыванию суммарного результата спортсмена
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                    for (int j = 0; j < array.Length - i - 1; j++)
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);

            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: ");
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                        Console.Write(_marks[i, j] + " ");
                    Console.WriteLine();
                    
                    
                }
                Console.WriteLine(TotalScore);
                Console.WriteLine();
            }

        }
    }
}
