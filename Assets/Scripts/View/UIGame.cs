using UnityEngine;

namespace View
{
    public class UIGame : MonoBehaviour
    {
        [SerializeField] private GameObject panelShip;
        public void UpdateShipState()
        {
            
        }

        public void UpdateGameState(bool isGame)
        {
            panelShip.SetActive(isGame);
        }
    }
}