using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Spawner_Module
{
    public class SpawnerContext : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _radius;
        [SerializeField] private float _spawnDelay;

        public GameObject Prefab => _prefab;
        public Transform SpawnPoint => _spawnPoint;
        public float Radius => _radius;
        public float SpawnDelay => _spawnDelay;

        public EcsPackedEntity Entity { get; private set; }

        public void Compose(EcsPackedEntity ecsPackedEntity)
        {
            Entity = ecsPackedEntity;
        }
    }
}