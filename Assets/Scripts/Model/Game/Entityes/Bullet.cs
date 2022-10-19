using UnityEngine;

namespace Model.Game.Entityes
{
    public class Bullet : Entity
    {
        public void Init(Vector3 vec)
        {
            LifeCount = 1;
            Rb.velocity = vec * 10;
        }
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Asteroid>())
                LifeCount--;
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }
}