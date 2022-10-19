using UnityEngine;

namespace Model.Game.Entities
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
        
        protected abstract void OnTriggerEnter2D(Collider2D other);

        protected abstract void Death();
    }
}