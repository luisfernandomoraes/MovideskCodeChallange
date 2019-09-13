using System;
using System.Linq;
using MovideskCodeChallenge.Sets.Extensions;

namespace MovideskCodeChallenge.Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Digite a primeira sequência de valores separado por vírgula: ");
                var firstSequence = Console.ReadLine()?.Split(',');
                Console.WriteLine("Digite a segunda sequência de valores separado por vírgula: ");
                var secondSequence = Console.ReadLine()?.Split(',');

                var unionResult = firstSequence.UnionWith(secondSequence);
                unionResult = unionResult.OrderBy(p => p).ToArray();

                var intersectResult = firstSequence.IntersectWith(secondSequence);
                intersectResult = intersectResult.OrderBy(p => p).ToArray();

                Console.WriteLine($"Intersecção: {string.Join(",", intersectResult)}");
                Console.WriteLine($"União: {string.Join(",", unionResult)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro processando conjuntos. Erro: {ex.Message}");
            }
        }
    }
}
