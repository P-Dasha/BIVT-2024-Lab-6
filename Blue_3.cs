using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Blue_3
    {
        public struct Participant
        {

            // поля
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;
            private bool _expelled;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return null;

                    int[] copy = new int[_penaltyTimes.Length];
                    Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);

                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;

                    int res = 0;
                    foreach (var item in _penaltyTimes)
                    {
                        res += item;
                    }
                    return res;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0) return false;
                    return _expelled;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
                _expelled = true;
            }

            // методы
            // добавляет в массив штрафов штрафное время в очередном матче
            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;
                if (time == 10) _expelled = false;

                int[] newArr = new int[_penaltyTimes.Length + 1];
                for (int i = 0; i < newArr.Length - 1; i++)
                {
                    newArr[i] = _penaltyTimes[i];
                }

                newArr[newArr.Length - 1] = time;
                _penaltyTimes = newArr;
            }

            // по возрастанию общего штрафного времени спортсмена
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length; i++)
                    for (int j = 0; j < array.Length - i - 1; j++)
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - Общее штрафное время: {TotalTime} исключение спортсмена: {IsExpelled}");
            }
        }
    }
}
