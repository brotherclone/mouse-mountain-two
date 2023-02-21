using System;
using MouseMountain.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace MouseMountain.Things
{
    public abstract class Character : BaseObject, IDamagable, IMouseable, IPlaceable
    {
        public string firstName;
        public string familyName;

        private int _level;

        public virtual int Level
        {
            get => _level;
            set => _level = value;
        }

        private float _strongness;

        public virtual float Strongness
        {
            get => _strongness;
            set => _strongness = value;
        }

        private float _adaptability;

        public virtual float Adaptibility
        {
            get => _adaptability;
            set => _adaptability = value;
        }

        private float _will;

        public virtual float Will
        {
            get => _will;
            set => _will = value;
        }

        private float _speed;

        public virtual float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private float _cunning;

        public virtual float Cunning
        {
            get => _cunning;
            set => _cunning = value;
        }

        private float _intelligence;

        public virtual float Intelligence
        {
            get => _intelligence;
            set => _intelligence = value;
        }

        private float _heartiness;

        public virtual float Heartiness
        {
            get => _heartiness;
            set => _heartiness = value;
        }

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

        public int HitPoints(int hitPoints)
        {
            var h = (int)_heartiness;
            return h + _level;
        }

        public void Damage(int damagePoints)
        {
            throw new System.NotImplementedException();
        }
    }
}