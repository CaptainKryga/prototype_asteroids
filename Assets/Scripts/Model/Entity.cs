using Unity.VisualScripting;
using UnityEngine;

namespace Model
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D Rb;
        [SerializeField] protected Transform Respawn;
        
        private int _lifeCount;
        protected int LifeCount
        {
            get => _lifeCount;
            set
            {
                _lifeCount = value;
                if (_lifeCount <= 0)
                {
                    Death();
                }
            }
        }

        public abstract void Init(Vector3 velocity);
        
        protected abstract void OnCollisionEnter2D(Collision2D other);

        protected abstract void Death();
    }
}