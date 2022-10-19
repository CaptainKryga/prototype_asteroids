using System;

namespace Model.Save
{
    [Serializable]
    public class SaveData
    {
        public readonly int Length;
        
        public GameTypes.ELevel[] Status;
        public float[] Size;
        public float[] SpawnDelay;
        public float[] Speed;
        public int[] LifeCount;
        public float[] Distance;

        public SaveData(int length)
        {
            Length = length;
        }
    }
}