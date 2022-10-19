using UnityEngine;
using View;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        [SerializeField] private ViewController _view;
        [SerializeField] private LoadSave _loadSave;
        [SerializeField] private LevelController _levelController;

        public void Init()
        {
            Level[] levels = _loadSave.Load();
            _view.UpdateMap(levels);
            _levelController.Init(levels);
        }

        public void StartGame(int level)
        {
            _levelController.StartGame(level);
            //levelController
            //view
        }

        public void EndGame(bool isWin, Level[] levels)
        {
            _loadSave.Save(levels);
            _view.UpdateMap(levels);
            _view.UpdateGameState(isWin);

        }

        public void UpdateShipState(int lifeCount)
        {
            _view.UpdateShipState(lifeCount);
        }
    }
}