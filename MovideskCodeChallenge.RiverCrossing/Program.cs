using System;
using System.Collections.Generic;
using MovideskCodeChallenge.RiverCrossing.Models;
namespace MovideskCodeChallenge.RiverCrossing
{
    class Program
    {
        public static River River;
        static void Main(string[] args)
        {
            var lion = new Character("Leão");
            var goat = new Character("Cabra");
            var hay = new Character("Feno");

            
            goat.IsDevouredBy = lion;
            hay.IsDevouredBy = goat;

            var rightRiverBank = new RiverBank("Direita");
            var leftRiverBank = new RiverBank("Esquerda");
            var personagens = new List<Character>
            {
                lion,
                goat,
                hay
            };
            leftRiverBank.Items = personagens;

            River = new River(rightRiverBank, leftRiverBank);

            while (River.RightRiverBank.Items.Count < 3)
            {
                Character pickedCharacter = null;

                while (pickedCharacter == null && (River.CurrentRiverBank.Items.Count > 1 || River.CurrentRiverBank == River.LeftRiverBank))
                {
                    pickedCharacter = River.CurrentRiverBank.Items[new Random().Next(0, River.CurrentRiverBank.Items.Count - 1)];

                    var remaining = River.CurrentRiverBank.Items.FindAll(p => p != pickedCharacter);

                    if (remaining.Count <= 1)
                    {
                        if (remaining.Count <= 0) continue;

                        if (remaining[0].IsDevouredBy == pickedCharacter ||
                            pickedCharacter.IsDevouredBy == remaining[0] ||
                            River.CurrentRiverBank != River.RightRiverBank) continue;

                        pickedCharacter = null;
                        break;
                    }

                    if (remaining[0].IsDevouredBy == remaining[1] || remaining[1].IsDevouredBy == remaining[0])
                    {
                        pickedCharacter = null;
                    }
                }

                PlayMove(pickedCharacter);
            }

            Console.ReadKey();
        }

        static void PlayMove(Character character)
        {
            if (character != null)
            {
                River.CurrentRiverBank.Items.Remove(character);
                River.ChangeRiverBank();
                River.CurrentRiverBank.Items.Add(character);
                Console.WriteLine($"Camponês e {character} para margem {River.CurrentRiverBank}");
            }
            else
            {
                River.ChangeRiverBank();
                Console.WriteLine($"Camponês para margem {River.CurrentRiverBank}");
            }
        }
    }
}
