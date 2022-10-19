using System;
using UnityEngine;

namespace Model.Game.Entities
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
            {
                if (other.GetComponent<Ship>())
                    LifeCount -= Int32.MaxValue;
                else
                    LifeCount--;
            }
        }

        protected override void Death()
        {
            Destroy(gameObject);
        }
    }
}