using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution1
{
    public class PhilosopherAsym
    {
        private readonly Table _table;
        private readonly int _leftFork;
        private readonly int _rightFork;
        private readonly int _id;
        private readonly Thread _thread;

        public PhilosopherAsym(int id, Table table)
        {
            _id = id;
            _table = table;
            _rightFork = id;
            _leftFork = (id + 1) % 5;

            _thread = new Thread(Run);
            _thread.Name = $"Philosopher-{id}";
            _thread.Start();
        }

        public Thread Thread => _thread;

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Philosopher {_id} is thinking ({i + 1})");

                if (_id == 4)
                {
                    _table.GetFork(_leftFork);
                    _table.GetFork(_rightFork);
                }
                else
                {
                    _table.GetFork(_rightFork);
                    _table.GetFork(_leftFork);
                }

                Console.WriteLine($"Philosopher {_id} is eating ({i + 1})");
                _table.PutFork(_leftFork);
                _table.PutFork(_rightFork);
            }

            Console.WriteLine($"Philosopher {_id} finished.");
        }
    }
}
