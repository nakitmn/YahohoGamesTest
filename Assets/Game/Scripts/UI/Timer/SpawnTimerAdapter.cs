using System;
using Game.Scripts.Game_Engine.Timer_Feature.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.UI.Timer
{
    public sealed class SpawnTimerAdapter
    {
        private readonly EcsWorld _world;
        private readonly TimerView _view;
        private readonly EcsPackedEntity _entity;

        public SpawnTimerAdapter(EcsWorld world, TimerView view, EcsPackedEntity entity)
        {
            _world = world;
            _view = view;
            _entity = entity;
        }

        public void Update()
        {
            if (_entity.Unpack(_world, out var entity))
            {
                var timerComponent = _world.GetPool<Timer_Component>().Get(entity);
                var remainSeconds = Mathf.CeilToInt(timerComponent.Remain);
                
                _view.SetTimerValue($"Spawn in {remainSeconds}");
            }
            else
            {
                _view.SetTimerValue(string.Empty);
            }
        }
    }
}