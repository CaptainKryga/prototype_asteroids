using System;
using Controller;
using UnityEngine;

namespace Model
{
    public class Ship : Entity
    {
        [SerializeField] private CustomInput _customInput;
        
        public Action<int> UpdateState_Action;

        public void Init(Vector3 velocity)
        {
            transform.position = Respawn.position;
            Rb.velocity = velocity;

            LifeCount = 3;
            
            _customInput.UpdateWASD_Action += Move;
            _customInput.UpdateMouseClick_Action += Attack;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Entity>())
            {
                LifeCount--;
                UpdateState_Action?.Invoke(LifeCount);
            }
        }

        protected override void Death()
        {
            _customInput.UpdateWASD_Action -= Move;
            _customInput.UpdateMouseClick_Action -= Attack;
            Debug.Log("Death");
        }

        private void Move(Vector2 vec)
        {
            if ((Rb.velocity + vec).magnitude > 10)
            {
                Rb.velocity += vec * Time.deltaTime;
            }
            else
            {
                Rb.velocity += vec;
            }

            Rb.velocity *= .9f;
        }

        private void Attack(Vector2 mouse)
        {
            
        }
    }
}