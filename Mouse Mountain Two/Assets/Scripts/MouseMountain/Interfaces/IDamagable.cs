namespace MouseMountain.Interfaces
{
    public interface IDamagable
    {
        int HitPoints(int hitPoints);
        void Damage(int damagePoints);
    }
}