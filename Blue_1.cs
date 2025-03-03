using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            // поля
            private string _name;
            private string _surname;
            private int _votes;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes { get { return _votes; } }

            // конструктор
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            // методы
            /* будет подсчитывать, сколько голосов из общего списка ответов соответствуют 
             * текущему кандидату (он(а) также находится в списке) 
             * Также метод должен сохранять это значение в поле количества голосов текущего кандидата
             */
            public int CountVotes(Response[] responses)
            {
                if (responses == null || responses.Length == 0) return 0;

                foreach (Response resp in responses)
                {
                    if (resp.Name == _name && resp.Surname == _surname)
                        _votes++;
                }
                return _votes;
            }

            /*публичный метод Print() для вывода информации о необходимых полях структуры */
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_votes} votes.");
            }
        }
    }
}
