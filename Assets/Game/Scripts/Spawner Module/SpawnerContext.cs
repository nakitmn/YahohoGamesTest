using System;
using DG.Tweening;
using Game.Scripts.UI.Timer;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Spawner_Module
{
    public class SpawnerContext : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _radius;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private TimerView _timerView;

        private DiContainer _diContainer;
        private SpawnTimerAdapter _spawnTimerAdapter;

        public GameObject Prefab => _prefab;
        public Transform SpawnPoint => _spawnPoint;
        public float Radius => _radius;
        public float SpawnDelay => _spawnDelay;

        public EcsPackedEntity Entity { get; private set; }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Compose(EcsPackedEntity packedEntity)
        {
            Entity = packedEntity;
            _spawnTimerAdapter = _diContainer.Instantiate<SpawnTimerAdapter>(new object[] {_timerView, packedEntity});
        }

        private void Update()
        {
            _spawnTimerAdapter.Update();
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
                    objectTransform.DOPunchPosition(Vector3.up, 0.3f, 1, 1f)
                        .SetLink(spawnedObject)
                );
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_spawnPoint.position, _radius);
            Gizmos.color = Color.white;
        }
    }
}