using CowMilking.Character.Player;
using CowMilking.Persistency;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CowMilking.Farm
{
    public class FarmManager : MonoBehaviour
    {
        public static FarmManager Instance { private set; get; }

        [SerializeField]
        private GameObject _cowPrefab;

        [SerializeField]
        private Transform _upgradeContainer;

        [SerializeField]
        private GameObject _upgradePrefab;

        private int _cowLayer;

        public List<FarmCowController> Cows { get; } = new();

        public ClickAction ClickAction { set; private get; }
        private FarmCowController _selectedCow;

        private Camera _cam;

        private void Awake()
        {
            Instance = this;
            SceneManager.LoadScene("CowManager", LoadSceneMode.Additive);

            _cam = Camera.main;

            _cowLayer = LayerMask.NameToLayer("Cow");
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
            if (value.performed && !_upgradeContainer.gameObject.activeInHierarchy)
            {
                _selectedCow = null;
                if (ClickAction != ClickAction.None)
                {
                    var hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero, float.MaxValue, 1 << _cowLayer);

                    if (hit.collider != null)
                    {
                        _selectedCow = hit.collider.gameObject.GetComponent<FarmCowController>();
                        if (ClickAction == ClickAction.Upgrade)
                        {
                            _upgradeContainer.gameObject.SetActive(true);
                            for (int i = 0; i < _upgradeContainer.childCount; i++)
                            {
                                Destroy(_upgradeContainer.GetChild(i).gameObject);
                            }

                            foreach (var element in CowManager.Instance.AllCows.Where(x => x.Element != ElementType.None && x.IsStartingCow))
                            {
                                var curr = element;

                                var go = Instantiate(_upgradePrefab, _upgradeContainer);
                                go.GetComponentInChildren<TMP_Text>().text = $"{curr.Element} Potion";
                                go.GetComponent<Button>().onClick.AddListener(new(() =>
                                {
                                    _selectedCow.Info = curr;
                                    _upgradeContainer.gameObject.SetActive(false);
                                    ClickAction = ClickAction.None;
                                }));
                            }
                            var cancel = Instantiate(_upgradePrefab, _upgradeContainer);
                            cancel.GetComponentInChildren<TMP_Text>().text = "Cancel";
                            cancel.GetComponent<Button>().onClick.AddListener(new(() =>
                            {
                                _upgradeContainer.gameObject.SetActive(false);
                                ClickAction = ClickAction.None;
                            }));
                        }
                    }

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
