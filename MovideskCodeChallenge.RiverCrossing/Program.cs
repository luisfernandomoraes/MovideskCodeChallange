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
                goat,
                hay,
                lion
            };
            leftRiverBank.Items = personagens;

            River = new River(rightRiverBank, leftRiverBank);

            // Enquanto os 3 não tiverem cruzado o rio para o lado direito
            while (River.LeftRiverBank.Items.Count != 0)
            {

                Character pickedCharacter;

                do
                {
                    pickedCharacter = River.CurrentRiverBank.Items[new Random().Next(0, River.CurrentRiverBank.Items.Count - 1)];

                    var remaining = River.CurrentRiverBank.Items.FindAll(p => p != pickedCharacter);

                    if (remaining.Count == 2)
                    {
                        if (remaining[0].IsDevouredBy == remaining[1] || remaining[1].IsDevouredBy == remaining[0])
                        {
                            pickedCharacter = null;
                        }
                    }

                    else if (remaining.Count == 0 && River.CurrentRiverBank == rightRiverBank)
                    {
                        pickedCharacter = null;
                        break;
                    }

                    else if(remaining.Count == 1 && pickedCharacter.IsDevouredBy != remaining[0] && remaining[0].IsDevouredBy != pickedCharacter && River.CurrentRiverBank != leftRiverBank )
                    {
                        pickedCharacter = null;
                        break;
                    }

                } while (pickedCharacter == null);


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
