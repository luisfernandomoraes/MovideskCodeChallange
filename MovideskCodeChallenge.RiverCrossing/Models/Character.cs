namespace MovideskCodeChallenge.RiverCrossing.Models
{
    public class Character
    {

        public Character(string especie)
        {
            Especie = especie;
        }

        public string Especie { get; }

        public Character IsDevouredBy { get; set; }

        public override string ToString()
        {
            return this.Especie;
        }
    }
}