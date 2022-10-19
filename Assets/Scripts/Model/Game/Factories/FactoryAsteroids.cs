using Model.Game.Entities;
using UnityEngine;

namespace Model.Game.Factories
{
    public class FactoryAsteroids : Factory
    {
        public override void Create(Level level)
        {
            Vector3 newPos = Respawn.position + Vector3.right * 
                (Random.Range(0, Respawn.localScale.x) - Respawn.localScale.x / 2);
            Asteroid go = Instantiate(Prefab, newPos, Quaternion.identity).GetComponent<Asteroid>();
            go.Init(level.Size, level.Speed, level.LifeCount);
            
            List.Add(go.gameObject);
        }
    }
}