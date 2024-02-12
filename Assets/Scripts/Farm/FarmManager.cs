using CowMilking.Persistency;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CowMilking.Farm
{
    public class FarmManager : MonoBehaviour
    {
        public static FarmManager Instance { private set; get; }

        [SerializeField]
        private GameObject _cowPrefab;

        private void Awake()
        {
            Instance = this;
            SceneManager.LoadScene("CowManager", LoadSceneMode.Additive);
        }

        private void Start()
        {
            foreach (var cow in PersistencyManager.Instance.SaveData.OwnedCows)
            {
                AddNewCow(cow);
            }
        }

        public void AddNewCow(string key)
        {
            var go = Instantiate(_cowPrefab, Vector2.zero, Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = CowManager.Instance.GetCow(key).Sprite;
        }
    }
}
