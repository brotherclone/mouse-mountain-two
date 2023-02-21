using System.Collections.Generic;
using MouseMountain.Interfaces;

namespace MouseMountain.Things
{
    public abstract class Inanimate: BaseObject, IDamagable, IMouseable, IPlaceable
    {
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
            throw new System.NotImplementedException();
        }
        public void Damage(int damagePoints)
        {
            throw new System.NotImplementedException();
        }
    }
}