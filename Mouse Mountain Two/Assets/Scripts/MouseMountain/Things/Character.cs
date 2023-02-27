using MouseMountain.Interfaces;

namespace MouseMountain.Things
{
    public abstract class Character : BaseObject, IPlaceable
    {
        public string firstName;
        public string familyName;
// POLYMORPHISM
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