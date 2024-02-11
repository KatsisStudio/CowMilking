using UnityEngine;

namespace CowMilking.SO
{
    [CreateAssetMenu(fileName = "SpawnableInfo", menuName = "ScriptableObject/SpawnableInfo")]
    public class SpawnableInfo : ScriptableObject
    {
        public GameObject Prefab;
    }
}