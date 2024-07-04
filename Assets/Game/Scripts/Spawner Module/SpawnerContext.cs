using DG.Tweening;
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

        public void OnSpawned(GameObject spawnedObject)
        {
            var objectTransform = spawnedObject.transform;

            DOTween.Sequence()
                .AppendCallback(() => objectTransform.localScale = Vector3.zero)
                .Append(
                    objectTransform.DOScale(Vector3.one, 0.25f)
                        .SetLink(spawnedObject)
                )
                .Join(
                    objectTransform.DOPunchPosition(Vector3.up, 0.3f,1,1f)
                        .SetLink(spawnedObject)
                );
        }
    }
}