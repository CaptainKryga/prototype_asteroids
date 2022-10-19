using Model;
using Model.Game;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private ViewController _view;

        [SerializeField] private GameObject _panelMap;
        [SerializeField] private Button[] _mapPoints;

        public void Restart()
        {
            UpdateMapState(true);
        }
        
        public void UpdateMap(Level[] levels)
        {
            for (int x = 0; x < levels.Length && x < _mapPoints.Length; x++)
            {
                _mapPoints[x].interactable = levels[x].Status != GameTypes.ELevel.closed;
                _mapPoints[x].image.color = levels[x].Status == GameTypes.ELevel.closed ? Color.red :
                    levels[x].Status == GameTypes.ELevel.opened ? Color.white : Color.green;
            }
        }
        
        public void UpdateMapState(bool isVisible)
        {
            _panelMap.SetActive(isVisible);
        }

        public void OnClick_SetLevel(int level)
        {
            _view.SetLevel(level);
            _panelMap.SetActive(false);
        }
    }
}