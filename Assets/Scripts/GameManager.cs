using CowMilking.SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CowMilking
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameObject[] _hiddenUIUntilStart;
        [SerializeField]
        private GameObject[] _visibleUIUntilStart;

        private SpawnableInfo _selectedInfo;
        private Tile _currentTile;

        private bool _didGameStart;

        private void Awake()
        {
            Instance = this;
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
            foreach (var elem in _hiddenUIUntilStart)
            {
                elem.SetActive(true);
            }
            foreach (var elem in _visibleUIUntilStart)
            {
                elem.SetActive(false);
            }
            _didGameStart = true;

            WaveManager.Instance.StartSpawn();
        }

        public void OnClick(InputAction.CallbackContext value)
        {
            if (value.performed && _selectedInfo != null)
            {
                if (_currentTile != null && _currentTile.TileContent == null)
                {
                    var go = Instantiate(_selectedInfo.Prefab, _currentTile.transform.position, Quaternion.identity);
                    _currentTile.TileContent = new(go, _selectedInfo);
                }
                _selectedInfo = null;
            }
        }
    }
}
