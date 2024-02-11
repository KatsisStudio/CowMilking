using CowMilking.SO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CowMilking
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        private SpawnableInfo _selectedInfo;

        private Tile _currentTile;

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
