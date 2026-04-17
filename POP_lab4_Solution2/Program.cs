namespace POP_lab4_Solution2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TableTwoWaiters table = new TableTwoWaiters();
            PhilosopherTwoWaiters[] philosophers = new PhilosopherTwoWaiters[5];

            for (int i = 0; i < 5; i++)
            {
                philosophers[i] = new PhilosopherTwoWaiters(i, table);
            }
        }
    }
}
