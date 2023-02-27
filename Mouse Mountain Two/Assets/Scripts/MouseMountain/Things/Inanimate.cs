using MouseMountain.Interfaces;
// INHERITANCE
namespace MouseMountain.Things
{
    public abstract class Inanimate: BaseObject,IPlaceable
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