using Controller;
using Model.Game;
using UnityEngine;

namespace View
{
    public class ViewController : MonoBehaviour
    {
        [SerializeField] private GlobalController _global;
        [SerializeField] private UIMenu _menu;
        [SerializeField] private UIGame _game;

        private int _saveLevel;
        
        public void Restart()
        {
            _menu.Restart();
            _game.Restart();
        }
        
        public void SetLevel(int level)
        {
            _saveLevel = level;
            RestartLevel();
        }
        
        public void RestartLevel()
        {
            _global.StartGame(_saveLevel);
            _game.Restart();
            _menu.UpdateMapState(false);
        }
        
        public void UpdateMap(Level[] levels)
        {
            _menu.UpdateMap(levels);
        }

        public void UpdateShipState(int lifeCount)
        {
            _game.UpdateShipState(lifeCount);
        }

        public void UpdateEndGameState(bool isWin)
        {
            _game.UpdateEndGameState(isWin);
        }
    }
    
}
