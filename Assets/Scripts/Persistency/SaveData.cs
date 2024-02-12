using CowMilking.Character.Player;
using System.Collections.Generic;

namespace CowMilking.Persistency
{
    public class SaveData
    {
        public string[] OwnedCows { set; get; } = new[] { "NEUTRAL", "NEUTRAL", "NEUTRAL" };
        public int Energy { set; get; }

        public Dictionary<ElementType, int> Elements { set; get; } = new()
        {
            { ElementType.Fire, 1 }
        };
    }
}