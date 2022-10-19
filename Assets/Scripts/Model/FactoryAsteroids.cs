﻿using UnityEngine;

namespace Model
{
    public class FactoryAsteroids : Factory
    {
        public override void Create(Level level)
        {
            Vector3 newPos = Respawn.position + Vector3.right * Random.Range(0, Respawn.localScale.x / 2);
            Asteroid go = Instantiate(Prefab, newPos, Quaternion.identity).GetComponent<Asteroid>();
            go.Init(level.Size, level.Speed, level.LifeCount);
        }
    }
}