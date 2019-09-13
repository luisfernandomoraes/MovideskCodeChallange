using System.Collections.Generic;

namespace MovideskCodeChallenge.RiverCrossing.Models
{
    /// <summary>
    /// Rio
    /// </summary>
    public class River
    {
        private RiverBank _currentRiverBank;

        public River(RiverBank rightRiverBank, RiverBank leftRiverBank)
        {
            RightRiverBank = rightRiverBank;
            LeftRiverBank = leftRiverBank;

            if (RightRiverBank.Items == null)
                RightRiverBank.Items = new List<Character>();
            if (LeftRiverBank.Items == null)
                LeftRiverBank.Items = new List<Character>();

            this.CurrentRiverBank = LeftRiverBank;
        }

        public RiverBank RightRiverBank { get; set; }
        public RiverBank LeftRiverBank { get; set; }


        public RiverBank CurrentRiverBank
        {
            get => _currentRiverBank;
            private set { _currentRiverBank = value; }
        }

        public RiverBank Other
        {
            get
            {
                if (_currentRiverBank == RightRiverBank)
                    return LeftRiverBank;
                else
                    return RightRiverBank;
            }
        }

        public void ChangeRiverBank()
        {
            if (CurrentRiverBank == RightRiverBank)
                CurrentRiverBank = LeftRiverBank;
            else
                CurrentRiverBank = RightRiverBank;
        }
    }
}