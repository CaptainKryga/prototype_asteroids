using UnityEngine;

namespace Model.Game.Entities
{
    public class BecomeVisible : MonoBehaviour
    {
        private bool _isVisible;
        void OnBecameInvisible()
        {
            if (_isVisible)
                Destroy(gameObject);
        }

        private void OnBecameVisible()
        {
            _isVisible = true;
        }
    }
}