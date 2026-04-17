namespace POP_lab4_Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            PhilosopherAsym[] philosophers = new PhilosopherAsym[5];

            for (int i = 0; i < 5; i++)
                philosophers[i] = new PhilosopherAsym(i, table);
        }
    }
}
