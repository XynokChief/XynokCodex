using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace XynokEntity.AnimPhasing.Data
{
    public interface IAnimState
    {
        string StateName { get; }
        bool IsMatch(AnimatorStateInfo stateInfo);
    }

    [Serializable]
    public class AnimLayer
    {
        public int layerIndex;
        public string layerName;

        [SerializeReference] public IAnimState[] states = Array.Empty<IAnimState>();

        private Dictionary<int, IAnimState> _cache = new();


        public IAnimState GetState(AnimatorStateInfo stateInfo)
        {
            if (_cache.TryGetValue(stateInfo.fullPathHash, out var state1)) return state1;
            foreach (var state in states)
            {
                if (!state.IsMatch(stateInfo)) continue;
                var hash = stateInfo.fullPathHash;
                if (state is SubStateMachineAnim subState)
                {
                    if (subState.IsMatch(stateInfo))
                    {
                        _cache.Add(hash, subState.GetState(hash));
                        return _cache[hash];
                    }
                }

                return state;
            }

            return null;
        }
    }


    [Serializable]
    public class SubStateMachineAnim : IAnimState
    {
        public string stateName;

        [SerializeReference] [HideDuplicateReferenceBox] [HideReferenceObjectPicker]
        public IAnimState[] states = Array.Empty<IAnimState>();

        public string StateName => stateName;
        private Dictionary<int, IAnimState> _cache = new();

        public IAnimState GetState(int hash)
        {
            return _cache.GetValueOrDefault(hash);
        }

        public bool IsMatch(AnimatorStateInfo stateInfo)
        {
            foreach (var state in states)
            {
                if (!state.IsMatch(stateInfo)) continue;
                _cache.Add(stateInfo.fullPathHash, state);
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public class NormalAnimState : IAnimState
    {
        public string stateName;
        public string StateName => stateName;

        public bool IsMatch(AnimatorStateInfo stateInfo)
        {
            return stateInfo.IsName(stateName);
        }
    }

    [Serializable]
    public class BlendTreeAnimState : IAnimState
    {
        public string stateName;
        public string[] motionNames;
        public string StateName => stateName;

        public bool IsMatch(AnimatorStateInfo stateInfo)
        {
            return stateInfo.IsName(stateName);
        }
    }
}