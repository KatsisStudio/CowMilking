using CowMilking.Character;
using CowMilking.Character.Player;
using CowMilking.SO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CowMilking
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameInfo _info;

        private SelectedData _selectedData;
        private GameObject _currentTile;

        private Camera _cam;

        private bool _didGameStart;

        private int _grassCount;

        private int _tileLayer;

        private void Awake()
        {
            Instance = this;

            SceneManager.LoadScene("CowManager", LoadSceneMode.Additive);

            _cam = Camera.main;

            _grassCount = _info.BaseGrassAmount;
            _tileLayer = LayerMask.NameToLayer("Tile");
        }

        private void Update()
        {
            var hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero, float.MaxValue, 1 << _tileLayer);

            if (hit.collider != null)
            {
                _currentTile = hit.collider.gameObject;
            }
            else
            {
                _currentTile = null;
            }
        }

        public void OnObjectSelection(SpawnableInfo info, PlacementButton button)
        {
            _selectedData = new() { Info = info, Button = button };
        }

        public void StartGame()
        {
            UIManager.Instance.ToggleGameStartUI();
            _didGameStart = true;

            WaveManager.Instance.StartSpawn();
        }

        public void IncreaseGrass(int amount)
        {
            _grassCount += amount;
            UpdateUI();
        }

        public void UpdateUI()
        {
            UIManager.Instance.SetGrassAmount(_grassCount);
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                //UIManager.Instance.HideInfoPanel();
                if (_currentTile != null)
                {
                    var tile = _currentTile.GetComponent<Tile>();
                    if (tile.TileContent != null)
                    {
                        /*if (tile.TileContent.Info is CowInfo info)
                        {
                            UIManager.Instance.ShowInfoPanel(tile.TileContent.Character, info);
                        }*/
                    }
                    else if (_selectedData != null)
                    {
                        var go = Instantiate(_selectedData.Info.Prefab, _currentTile.transform.position, Quaternion.identity);

                        go.GetComponent<ICharacter>().Info = _selectedData.Info;

                        tile.TileContent = new(go, _selectedData.Info, go.GetComponent<ICharacter>());

                        _grassCount -= _selectedData.Info.Cost;
                        UpdateUI();

                        UIManager.Instance.DestroyPlacementButton(_selectedData.Button);
                    }
                }
                _selectedData = null;
            }
        }
    }

    public class SelectedData
    {
        public SpawnableInfo Info;
        public PlacementButton Button;
    }
}
