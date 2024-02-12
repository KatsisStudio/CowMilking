using CowMilking.Persistency;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CowMilking.Farm
{
    public class FarmManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cowPrefab;

        private void Awake()
        {
            SceneManager.LoadScene("CowManager", LoadSceneMode.Additive);
        }

        private void Start()
        {
            foreach (var cow in PersistencyManager.Instance.SaveData.OwnedCows)
            {
                var go = Instantiate(_cowPrefab, Vector2.zero, Quaternion.identity);
                go.GetComponent<SpriteRenderer>().sprite = CowManager.Instance.GetCow(cow).Sprite;
            }
        }
    }
}
