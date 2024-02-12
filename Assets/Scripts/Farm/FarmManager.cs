using CowMilking.Persistency;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CowMilking.Farm
{
    public class FarmManager : MonoBehaviour
    {
        public static FarmManager Instance { private set; get; }

        [SerializeField]
        private GameObject _cowPrefab;

        public List<FarmCowController> Cows { get; } = new();

        public ClickAction ClickAction { set; private get; }

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
            var info = CowManager.Instance.GetCow(key);
            go.GetComponent<SpriteRenderer>().sprite = info.Sprite;

            var fcc = go.GetComponent<FarmCowController>();
            fcc.Info = info;
            Cows.Add(fcc);
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                if (ClickAction != ClickAction.None)
                {
                    foreach (var cow in Cows)
                    {
                        cow.Allow();
                    }
                    ClickAction = ClickAction.None;
                }
            }
        }
    }

    public enum ClickAction
    {
        None,
        Upgrade,
        Milk
    }
}
