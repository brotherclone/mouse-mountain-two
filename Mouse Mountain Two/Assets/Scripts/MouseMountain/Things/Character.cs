using System;
using MouseMountain.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace MouseMountain.Things
{
    public abstract class Character : BaseObject, IPlaceable
    {
        public string firstName;
        public string familyName;

       public override string GetName()
        {
            return $"{firstName} {familyName}";
        }

        protected override void Added()
        {
            throw new System.NotImplementedException();
        }

        protected override void Removed()
        {
            throw new System.NotImplementedException();
        }
        

        public void Damage(int damagePoints)
        {
            throw new System.NotImplementedException();
        }
    }
}