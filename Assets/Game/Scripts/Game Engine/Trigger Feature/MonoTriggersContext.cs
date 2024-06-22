using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game_Engine.Trigger_Feature
{
    public class MonoTriggersContext : MonoBehaviour
    {
        [SerializeField] private List<Collider> _colliders = new();
        
        private EcsWorld _world;
        
        public  EcsPackedEntity Entity { get; private set; }

        [Inject]
        public void Construct(EcsWorld ecsWorld)
        {
            _world = ecsWorld;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_colliders.Contains(other))
            {
                return;
            }
            
            _colliders.Add(other);
        }

        private void OnTriggerStay(Collider other)
        {
            for (var i = 0; i < _colliders.Count; i++)
            {
                if (_colliders[i].enabled == false)
                {
                    _colliders.RemoveAt(i);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _colliders.Remove(other);
        }

        public void Compose(EcsPackedEntity owner)
        {
            if (owner.Unpack(_world, out  var entity) == false)
            {
                return;
            }
            
            Entity = owner;

            var triggersPool = _world.GetPool<Triggers_Component>();
            ref var triggersComponent = ref triggersPool.Add(entity);
            
            triggersComponent.Owner = Entity;
            triggersComponent.Colliders = _colliders;
        }
    }
}