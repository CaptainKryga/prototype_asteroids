using System.Collections.Generic;
using UnityEngine;

namespace Model.Game.Factories
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] protected GameObject Prefab;
        [SerializeField] protected Transform Respawn;

        protected List<GameObject> List = new List<GameObject>();

        public abstract void Create(Level level);

        public void Clear()
        {
            for (int x = 0; x < List.Count; x++)
            {
                if (List[x])
                    Destroy(List[x]);
            }
        }
    }
}