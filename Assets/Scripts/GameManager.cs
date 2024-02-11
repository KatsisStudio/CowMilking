using CowMilking.Character;
using CowMilking.SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CowMilking
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameInfo _info;

        private SpawnableInfo _selectedInfo;
        private GameObject _currentTile;

        private Camera _cam;

        private bool _didGameStart;

        private int _grassCount;

        private int _tileLayer;

        private void Awake()
        {
            Instance = this;

            _cam = Camera.main;

            _grassCount = _info.BaseGrassAmount;
            _tileLayer = LayerMask.NameToLayer("Tile");
        }

        private void Start()
        {
            UpdateUI();
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

        public void OnObjectSelection(SpawnableInfo info)
        {
            _selectedInfo = info;
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

        private void UpdateUI()
        {
            UIManager.Instance.SetGrassAmount(_grassCount);
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                UIManager.Instance.HideInfoPanel();
                if (_currentTile != null)
                {
                    var tile = _currentTile.GetComponent<Tile>();
                    if (tile.TileContent != null)
                    {
                        if (tile.TileContent.Info is CowInfo info)
                        {
                            UIManager.Instance.ShowInfoPanel(tile.TileContent.Character, info);
                        }
                    }
                    else if (_selectedInfo != null)
                    {
                        var go = Instantiate(_selectedInfo.Prefab, _currentTile.transform.position, Quaternion.identity);

                        go.GetComponent<ICharacter>().Info = _selectedInfo;

                        tile.TileContent = new(go, _selectedInfo, go.GetComponent<ICharacter>());

                        _grassCount -= _selectedInfo.Cost;
                        UpdateUI();
                    }
                }
                _selectedInfo = null;
            }
        }
    }
}
