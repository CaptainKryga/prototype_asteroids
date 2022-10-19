using System.Collections;
using Model.Game.Entityes;
using Model.Game.Factories;
using UnityEngine;

namespace Model.Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ModelController _model;
        private Level[] _levels;
        [SerializeField] private FactoryAsteroids _factoryAsteroids;
        [SerializeField] private Ship _ship;

        private Level _levelActual;
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

            _isLoop = true;

            StartCoroutine(GameLoop());
        }

        private void UpdateShipState(int lifeCount)
        {
            _model.UpdateShipState(lifeCount);
            
            if (lifeCount <= 0)
                EndGame(false);
        }

        private void EndGame(bool isWin)
        {
            _isLoop = false;
            
            _factoryAsteroids.Clear();
            
            if (isWin)
                _ship.WinUnSubscribe();
            
            _levelActual.Status = GameTypes.ELevel.completed;
            
            for (int x = 0; x < _levels.Length; x++)
                if (_levels[x] == _levelActual && x + 1 < _levels.Length)
                {
                    _levels[x + 1].Status = GameTypes.ELevel.opened;
                    break;
                }
            
            _model.EndGame(isWin, _levels);
        }

        private IEnumerator GameLoop()
        {
            float delay = _levelActual.SpawnDelay;
            float distance = 0;
            while (_isLoop)
            {
                delay -= Time.deltaTime;
                distance += Time.deltaTime;
                
                if (delay < 0)
                {
                    _factoryAsteroids.Create(_levelActual);
                    delay = _levelActual.SpawnDelay;
                }

                if (distance >= _levelActual.Distance)
                {
                    EndGame(true);
                }
                    
                yield return new WaitForEndOfFrame();
            }
            yield break;
        }
    }
}