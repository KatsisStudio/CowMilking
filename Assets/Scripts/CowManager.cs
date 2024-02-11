using CowMilking.SO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CowMilking
{
    public class CowManager : MonoBehaviour
    {
        public static CowManager Instance { private set; get; }

        [SerializeField]
        private CowInfo[] _cows;
        private Dictionary<string, CowInfo> _cowsDicts;

        public CowInfo GetCow(string id) => _cowsDicts[id];

        private void Awake()
        {
            Instance = this;
            _cowsDicts = _cows.ToDictionary(x => x.Key);
        }
    }
}
