using UnityEngine;

namespace CowMilking.Character.Player
{
    public class PlacementDropDown : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        public Transform Container => _container;

        public void OnClick()
        {
            Container.gameObject.SetActive(!Container.gameObject.activeInHierarchy);
        }
    }
}
