using CowMilking.Character;
using CowMilking.SO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CowMilking
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameInfo _info;

        private SpawnableInfo _selectedInfo;
        private Tile _currentTile;

        private bool _didGameStart;

        private int _grassCount;

        private void Awake()
        {
            Instance = this;

            _grassCount = _info.BaseGrassAmount;
        }

        private void Start()
        {
            UpdateUI();
        }

        public void HoverTileEnter(Tile t)
        {
            _currentTile = t;
        }

        public void HoverTileExit(Tile t)
        {
            if (_currentTile != null && _currentTile.GetInstanceID() == t.GetInstanceID())
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
            if (value.performed && _selectedInfo != null)
            {
                if (_currentTile != null && _currentTile.TileContent == null)
                {
                    var go = Instantiate(_selectedInfo.Prefab, _currentTile.transform.position, Quaternion.identity);

                    go.GetComponent<ICharacter>().Info = _selectedInfo;

                    _currentTile.TileContent = new(go, _selectedInfo, go.GetComponent<ICharacter>());

                    _grassCount -= _selectedInfo.Cost;
                    UpdateUI();
                }
                _selectedInfo = null;
            }
        }
    }
}
