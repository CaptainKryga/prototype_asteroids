using UnityEngine;
using View;

namespace Model
{
    public class ModelController : MonoBehaviour
    {
        [SerializeField] private ViewController _view;
        [SerializeField] private LoadSave _loadSave;
        [SerializeField] private LevelController _levelController;

        public void Load()
        {
            //saveload
            //levelController
        }

        private void Save(Level[] levels)
        {
            //saveload
        }

        public void StartGame(int level)
        {
            //levelController
            //view
        }

        public void EndGame(bool isWin, Level[] levels)
        {
            //save
            //view
        }

        public void UpdateShipState(int lifeCount)
        {
            //view
        }
    }
}