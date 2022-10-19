using UnityEngine;

namespace Model.Game.Factories
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] protected GameObject Prefab;
        [SerializeField] protected Transform Respawn;

        public abstract void Create(Level level);
    }
}