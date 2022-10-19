using System;
using Controller;
using Model.Game.Factories;
using UnityEngine;

namespace Model.Game.Entities
{
    public class Ship : Entity
    {
        [SerializeField] private CustomInput _customInput;
        [SerializeField] private FactoryBullets _factoryBullets;

        public Action<int> UpdateState_Action;

        public void Init(Vector3 velocity)
        {
            transform.position = Respawn.position;
            Rb.velocity = velocity;

            LifeCount = 3;
            
            _customInput.UpdateWASD_Action += Move;
            _customInput.UpdateMouseClick_Action += Attack;
            
            UpdateState_Action?.Invoke(LifeCount);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Asteroid>())
            {
                LifeCount--;
                UpdateState_Action?.Invoke(LifeCount);
            }
        }

        protected override void Death()
        {
            _factoryBullets.Clear();
            
            _customInput.UpdateWASD_Action -= Move;
            _customInput.UpdateMouseClick_Action -= Attack;
            Debug.Log("Death");
        }

        public void WinUnSubscribe()
        {
            _factoryBullets.Clear();

            _customInput.UpdateWASD_Action -= Move;
            _customInput.UpdateMouseClick_Action -= Attack;
            Debug.Log("Win");
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
            _factoryBullets.Create(null);
        }
    }
}