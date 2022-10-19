using Model;
using UnityEngine;

namespace Controller
{
    public class GlobalController : MonoBehaviour
    {
        [SerializeField] private ModelController _model;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _model.Init();
        }

        public void StartGame(int level)
        {
            _model.StartGame(level);
        }
    }
}
