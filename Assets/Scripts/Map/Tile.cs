using UnityEngine;

namespace CowMilking
{
    public class Tile : MonoBehaviour
    {
        private void OnMouseEnter()
        {
            GameManager.Instance.HoverTileEnter(this);
        }

        private void OnMouseExit()
        {
            GameManager.Instance.HoverTileExit(this);
        }
    }
}
