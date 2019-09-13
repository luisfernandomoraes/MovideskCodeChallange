using System;

namespace MovideskCodeChallenge.RomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;
            do
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Digite um número entre 1 e 1000:");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(RomanNumbers.ToRomanNumbers(numeroDigitado));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro convertendo para romano: {ex.Message}");
                }
                catch
                {
                    throw;
                }

                Console.WriteLine("Deseja continuar? (S/N - Padrão N)");
                option = Console.ReadLine();
            } while (option != null && option.ToUpper() == "S");
        }
    }
}
