using Controller;
using Model;
using UnityEngine;

namespace View
{
    public class ViewController : MonoBehaviour
    {
        [SerializeField] private GlobalController _global;
        [SerializeField] private UIMenu _menu;
        [SerializeField] private UIGame _game;

        public void SetLevel(int level)
        {
            _global.StartGame(level);
            _game.UpdateGameState(true);
        }
        
        public void UpdateMap(Level[] levels)
        {
            _menu.UpdateMap(levels);
        }

        public void UpdateShipState(int lifeCount)
        {
            _game.UpdateShipState(lifeCount);
        }

        public void UpdateGameState(bool isWin)
        {
            _menu.UpdateGameState(isWin);
            _game.UpdateGameState(false);
        }
    }
    
}
