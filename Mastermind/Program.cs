namespace Mastermind 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Mastermind");
            Mastermind mastermind = new Mastermind();
            mastermind.Play();
        }
    }
}