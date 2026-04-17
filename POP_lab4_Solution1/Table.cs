using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution1
{
    public class Table
    {
        private readonly Semaphore[] _forks = new Semaphore[5];

        public Table()
        {
            for (int i = 0; i < _forks.Length; i++)
                _forks[i] = new Semaphore(1, 1);
        }

        public void GetFork(int id)
        {
            _forks[id].WaitOne();
        }

        public void PutFork(int id)
        {
            _forks[id].Release();
        }
    }
}
