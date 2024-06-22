using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Game_Engine.Trigger_Feature
{
    public struct Triggers_Component
    {
        public EcsPackedEntity Owner;
        public List<Collider> Colliders;
    }
}