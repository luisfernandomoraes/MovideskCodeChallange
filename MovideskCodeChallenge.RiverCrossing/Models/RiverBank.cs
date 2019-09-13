using System.Collections.Generic;

namespace MovideskCodeChallenge.RiverCrossing.Models
{
    /// <summary>
    /// Margem do Rio
    /// </summary>
    public class RiverBank
    {
        public RiverBank(string lado)
        {
            Lado = lado;
        }

        public List<Character> Items { get; set; }
        public string Lado { get; set; }

        public override string ToString()
        {
            return this.Lado;
        }
    }
}