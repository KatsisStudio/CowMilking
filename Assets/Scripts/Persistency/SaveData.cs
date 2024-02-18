using CowMilking.Character.Player;
using System.Collections.Generic;

namespace CowMilking.Persistency
{
    public class SaveData
    {
        public List<string> OwnedCows { set; get; } = new();
        public int Energy { set; get; } = 70;

        public Dictionary<int, Dictionary<int, int>> QuestProgress = new();

        public Dictionary<ElementType, int> Potions { set; get; } = new()
        {
            { ElementType.Fire, 1 }
        };

        public void RemovePotion(ElementType e)
        {
            if (!Potions.ContainsKey(e)) return;
            if (Potions[e] == 1) Potions.Remove(e);
            else Potions[e]--;
        }

        public void UpdateQuestProgress(int questID, int goalID)
        {
            if (!QuestProgress.ContainsKey(questID))
            {
                QuestProgress.Add(questID, new());
            }
            if (!QuestProgress[questID].ContainsKey(goalID))
            {
                QuestProgress[questID].Add(goalID, 0);
            }

            QuestProgress[questID][goalID]++;
            PersistencyManager.Instance.Save();
        }

        public void ResetQuestProgress(int questID, int goalID)
        {
            if (!QuestProgress.ContainsKey(questID))
            {
                QuestProgress.Add(questID, new());
            }
            if (!QuestProgress[questID].ContainsKey(goalID))
            {
                QuestProgress[questID].Add(goalID, 0);
            }

            QuestProgress[questID][goalID] = 0;
            PersistencyManager.Instance.Save();
        }

        public int GetQuestProgress(int questID, int goalID)
        {
            if (!QuestProgress.ContainsKey(questID) || !QuestProgress[questID].ContainsKey(goalID)) return 0;

            return QuestProgress[questID][goalID];
        }
    }
}