using System;
using UnityEngine;
using XynokSourceGenerator.Entities;

namespace Runtime.TestEntity.Item
{
    [Serializable]
    public class SwordAbi : AItemAbility
    {
        protected override void OnInit()
        {
            Debug.Log("sword init");
        }

        protected override void OnExecute()
        {
        }

        protected override void OnInterrupted()
        {
            Debug.Log("sword interupt");
        }

        public override void Reset()
        {
            Debug.Log("sword reset");
        }

        protected override void OnDispose()
        {
            Debug.Log("sword dispose");
        }
    }
}