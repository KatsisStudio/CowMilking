using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "GameInfo", menuName = "ScriptableObject/GameInfo")]
    public class GameInfo : ScriptableObject
    {
        public int BaseGrassAmount;
    }
}