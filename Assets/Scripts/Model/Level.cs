namespace Model
{
    public class Level
    {
        private GameTypes.ELevel _status;
        private float _size;
        private float _spawnDelay;
        private float _speed;
        private int _lifeCount;
        private float _distance;
        
        public GameTypes.ELevel Status { get => _status; set => _status = value; }
        public float Size { get => _size; }
        public float SpawnDelay { get => _spawnDelay; }
        public float Speed { get => _speed; }
        public int LifeCount { get => _lifeCount; }
        public float Distance { get => _distance; }

        public Level(GameTypes.ELevel status, float size, float spawnDelay, float speed,
            int lifeCount, float distance)
        {
            _status = status;
            _size = size;
            _spawnDelay = spawnDelay;
            _speed = speed;
            _lifeCount = lifeCount;
            _distance = distance;
        }
        
        public Level(int id)
        {
            _status = id == 0 ? GameTypes.ELevel.opened : GameTypes.ELevel.closed;

            _size = UnityEngine.Random.Range(.5f, 5);
            _spawnDelay = UnityEngine.Random.Range(.5f, 2);
            _speed = UnityEngine.Random.Range(.5f, 10);
            _lifeCount = UnityEngine.Random.Range(1, 4);
            _distance = UnityEngine.Random.Range(30, 100);
        }
    }
}