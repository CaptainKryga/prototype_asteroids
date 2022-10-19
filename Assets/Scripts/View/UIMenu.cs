using Model;
using Model.Game;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private ViewController _view;

        [SerializeField] private GameObject panelMap;
        [SerializeField] private Button[] mapPoints;

        public void UpdateMap(Level[] levels)
        {
            for (int x = 0; x < levels.Length && x < mapPoints.Length; x++)
            {
                mapPoints[x].interactable = levels[x].Status != GameTypes.ELevel.closed;
                mapPoints[x].image.color = levels[x].Status == GameTypes.ELevel.closed ? Color.red :
                    levels[x].Status == GameTypes.ELevel.opened ? Color.white : Color.green;
            }
        }
        
        public void UpdateGameState(bool isWin)
        {
            panelMap.SetActive(true);
        }

        public void OnClick_SetLevel(int level)
        {
            _view.SetLevel(level);
            panelMap.SetActive(false);
        }
    }
}