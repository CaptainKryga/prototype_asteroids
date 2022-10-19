using UnityEngine;

namespace Model
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ModelController _model;
        [SerializeField] private Level[] _levels;
        [SerializeField] private FactoryAsteroids _factoryAsteroids;
        [SerializeField] private Ship _ship;

        [SerializeField] private Level _levelActual;
        [SerializeField] private float _distance;
        [SerializeField] private bool _isLoop;
        
        private void OnEnable()
        {
            _ship.UpdateState_Action += UpdateShipState;
        }

        private void OnDisable()
        {
            _ship.UpdateState_Action -= UpdateShipState;
        }

        public void Init(Level[] levels)
        {
            _levels = levels;
        }

        public void StartGame(int level)
        {
            _levelActual = _levels[level];

            _ship.Init(Vector3.zero);

            GameLoop();
        }

        private void UpdateShipState(int lifeCount)
        {
            if (lifeCount <= 0)
                EndGame();
        }

        private void EndGame()
        {
            _levelActual.Status = GameTypes.ELevel.completed;
            
            for (int x = 0; x < _levels.Length; x++)
                if (_levels[x] == _levelActual && x + 1 < _levels.Length)
                {
                    _levels[x + 1].Status = GameTypes.ELevel.opened;
                    break;
                }
            
            _model.EndGame(true, _levels);
        }

        private void GameLoop()
        {
            // _factoryAsteroids.CreateAsteroid();
        }
    }
}