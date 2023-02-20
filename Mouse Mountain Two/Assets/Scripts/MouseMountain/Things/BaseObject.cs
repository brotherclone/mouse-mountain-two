using System.Collections.Generic;
using MouseMountain.Interfaces;
using UnityEngine;

namespace MouseMountain.Things
{
    public abstract class BaseObject : MonoBehaviour, IMouseable
    {
        public virtual string GetName()
        {
            return "Mouse Mountain Base Object";
        }

        public virtual int GetId()
        {
            return 0;
        }

        public virtual List<string> GetCapabilities()
        {
            return new List<string>();
        }

        protected abstract void Added();
        protected abstract void Removed();

        public void Click(GameObject gameObject)
        {
            
        }
    }
}