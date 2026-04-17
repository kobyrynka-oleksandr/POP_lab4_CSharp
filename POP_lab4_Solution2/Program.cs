namespace POP_lab4_Solution2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TableWaiter table = new TableWaiter();
            PhilosopherWaiter[] philosophers = new PhilosopherWaiter[5];

            for (int i = 0; i < 5; i++)
            {
                philosophers[i] = new PhilosopherWaiter(i, table);
            }
        }
    }
}
