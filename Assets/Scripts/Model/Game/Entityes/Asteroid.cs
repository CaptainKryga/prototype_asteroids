using UnityEngine;

namespace Model.Game.Entityes
{
    public class Asteroid : Entity
    {
        public void Init(float size, float speed, int lifeCount)
        {
            transform.localScale = new Vector3(size, size, 1);
            Rb.velocity = Vector2.down * speed;
            
            transform.SetParent(Respawn);

            LifeCount = lifeCount;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Entity>())
                Death();
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }
}