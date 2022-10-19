using Controller;
using Model;
using UnityEngine;

namespace View
{
    public class ViewController : MonoBehaviour
    {
        [SerializeField] private GlobalController _global;

        public void UpdateMap(Level[] levels)
        {
            //map points
        }

        public void UpdateShipState()
        {
            //life
        }

        public void UpdateGameState()
        {
            //win?
        }
    }
    
}
