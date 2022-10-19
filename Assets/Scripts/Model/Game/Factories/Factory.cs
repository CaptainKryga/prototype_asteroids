using UnityEngine;

namespace Model
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] protected GameObject Prefab;
        [SerializeField] protected Transform Respawn;

        public abstract void Create(Level level);
    }
}