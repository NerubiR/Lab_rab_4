using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace parl_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Run(() => GenerateNumber());
            var t2 = Task.Run(() => GenerateNumbers(t1.Result));
            var t3 = Task.Run(() => CalcSum(t2.Result));
            var t4 = Task.Run(() => TransformToString(t3.Result));
            Console.WriteLine($"Random: {t1.Result} - Summs: {t3.Result} - Tostring: {t4.Result}");
        }

        static Task<int> GenerateNumber()
        {
            Random rnd = new Random();
            int ss = rnd.Next(0, 100);

            return Task.FromResult(ss);
        }
        static Task<List<double>> GenerateNumbers(int count)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Random().NextDouble());
            }
            return Task.FromResult(list);
            //return list;
        }
        static Task<double> CalcSum(List<double> numbers)
        {
            var summs = numbers.Sum(s => s);
            return Task.FromResult(summs);
        }
        static  Task<string> TransformToString(double number)
        {
            return Task.FromResult(number.ToString());
        }
    }
}