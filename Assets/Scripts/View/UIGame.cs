using TMPro;
using UnityEngine;

namespace View
{
    public class UIGame : MonoBehaviour
    {
        [SerializeField] private ViewController _view;
        
        [SerializeField] private TMP_Text _textLifeCount;
        
        [SerializeField] private GameObject _panelEndGame;
        [SerializeField] private TMP_Text _textEndGame;

        public void Restart()
        {
            _panelEndGame.SetActive(false);
        }
        
        public void UpdateShipState(int lifeCount)
        {
            _textLifeCount.text = "Life's: " + lifeCount;
        }

        public void UpdateEndGameState(bool isWin)
        {
            _panelEndGame.SetActive(true);
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