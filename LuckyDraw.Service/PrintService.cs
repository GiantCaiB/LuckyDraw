using LuckyDraw.Service.Interface.Interfaces;

namespace LuckyDraw.Service
{
    public class PrintService : IPrintService
    {
        public void Print(IEnumerable<IEnumerable<int>> results)
        {
            foreach (var result in results)
            {
                foreach (var number in result)
                    Console.Write(number + " ");
                Console.WriteLine();
            }
        }
    }
}
