using Model.Game.Entityes;
using UnityEngine;

namespace Model.Game.Factories
{
    public class FactoryBullets : Factory
    {
        public override void Create(Level level)
        {
            Vector3 newPos = Respawn.position;
            Bullet go = Instantiate(Prefab, newPos, Quaternion.identity).GetComponent<Bullet>();
            go.Init(Vector3.up);
        }
    }
}