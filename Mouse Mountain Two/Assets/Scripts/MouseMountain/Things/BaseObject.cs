using System;
using System.Collections.Generic;
using MouseMountain.Interfaces;
using UnityEngine;

namespace MouseMountain.Things
{
    public abstract class BaseObject : MonoBehaviour, IMouseable
    {
        public GameObject body;

        public virtual string GetName()
        {
            return "Mouse Mountain Base Object";
        }
 
        public virtual List<string> GetCapabilities()
        {
            return new List<string>();
        }

        protected abstract void Added();
        protected abstract void Removed();

        public void Click(GameObject gameObject)
        {
            Debug.Log("click");
        }
    }
}