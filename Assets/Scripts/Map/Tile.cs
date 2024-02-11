using CowMilking.SO;
using UnityEngine;

namespace CowMilking
{
    public class Tile : MonoBehaviour
    {
        public TileContent TileContent { set; get; }

        private void OnMouseEnter()
        {
            GameManager.Instance.HoverTileEnter(this);
        }

        private void OnMouseExit()
        {
            GameManager.Instance.HoverTileExit(this);
        }
    }

    public class TileContent
    {
        public TileContent(GameObject obj, SpawnableInfo info)
        {
            Object = obj;
            Info = info;
        }

        public GameObject Object { private set; get; }
        public SpawnableInfo Info { private set; get; }
    }
}
