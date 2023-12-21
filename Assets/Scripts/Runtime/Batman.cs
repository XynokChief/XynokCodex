using System;
using System.Collections.Generic;
using UnityEngine;
using XynokConvention.APIs;
using XynokConvention.Data.Binding;
using XynokConvention.Procedural;
using XynokSourceGenerator.Entities;
using XynokSourceGenerator.Entities.Data;

namespace Runtime
{
    [Serializable]
    public class CanRun : IValidator
    {
        public bool biggerThanZero;

        public bool IsValid()
        {
            return biggerThanZero;
        }
    }

    [Serializable]
    public class Run : ACharacterAbility
    {
        protected override void Init()
        {
        }

        protected override void OnExecute()
        {
            Debug.Log($"{owner.Resource.ResourceId} is running");
        }

        protected override void OnDispose()
        {
        }

        public override void Reset()
        {
        }
    }

    public class Batman : ACharacterMono
    {
        private Dictionary<CharacterStateFlag, bool> _stateFlags = new Dictionary<CharacterStateFlag, bool>();

        public BoolData x;
        public BoolData y;

        private void Start()
        {
            var x = CurrentState.Value.HasFlag(CharacterStateFlag.Idling);
            SetDependency(Resource);
        }
    }
}