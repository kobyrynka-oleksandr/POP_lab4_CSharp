using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution3
{
    public class TableForkLimit
    {
        private readonly Semaphore[] _forks = new Semaphore[5];
        private int _holdingCount = 0;
        private readonly object _monitor = new object();

        public TableForkLimit()
        {
            for (int i = 0; i < _forks.Length; i++)
                _forks[i] = new Semaphore(1, 1);
        }

        public void AcquireForks(int right, int left)
        {
            lock (_monitor)
            {
                while (_holdingCount >= 4)
                {
                    Console.WriteLine("  [Blocked] max fork-holders reached, waiting...");
                    Monitor.Wait(_monitor);
                }

                _holdingCount++;
            }

            _forks[right].WaitOne();
            _forks[left].WaitOne();
        }

        public void ReleaseForks(int left, int right)
        {
            _forks[left].Release();
            _forks[right].Release();

            lock (_monitor)
            {
                _holdingCount--;
                Monitor.PulseAll(_monitor);
            }
        }
    }
}
