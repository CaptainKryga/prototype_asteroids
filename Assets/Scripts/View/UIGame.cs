using TMPro;
using UnityEngine;

namespace View
{
    public class UIGame : MonoBehaviour
    {
        [SerializeField] private ViewController _view;
        
        [SerializeField] private GameObject _panelShip;
        [SerializeField] private TMP_Text _textLifeCount;
        
        [SerializeField] private GameObject _panelEndGame;
        [SerializeField] private TMP_Text _textEndGame;

        public void Restart()
        {
            _panelShip.SetActive(false);
            _panelEndGame.SetActive(false);
        }
        
        public void UpdateShipState(int lifeCount)
        {
            _textLifeCount.text = "Life's: " + lifeCount;
        }

        public void UpdatePanelShipState(bool isVisible)
        {
            _panelShip.SetActive(isVisible);
            _panelEndGame.SetActive(!isVisible);
        }
        
        public void UpdateEndGameState(bool isWin)
        {
            _textEndGame.text = isWin ? "Win" : "Defeat";
        }
        
        public void OnClick_Restart()
        {
            _view.RestartLevel();
        }

        public void OnClick_ReturnOnMap()
        {
            _view.Restart();
        }
    }
}