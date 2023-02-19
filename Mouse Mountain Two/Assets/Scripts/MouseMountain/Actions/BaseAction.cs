using System.Collections.Generic;
using UnityEngine;

namespace MouseMountain.Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        public virtual string GetName()
        {
            return "Mouse Mountain Base Action";
        }
        public virtual int GetId()
        {
            return 0;
        }
        protected abstract void Grant();
        protected abstract void RemoveGrant();
        protected abstract void AddTarget();
        protected abstract void RemoveTarget();
        protected abstract void BeforeAction();
        protected abstract void StartAction();
        protected abstract void DuringAction();
        protected abstract void AfterAction();
    }
}