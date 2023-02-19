namespace MouseMountain.Interfaces
{
    public interface IQueueable
    {
        void Priority(float priorityLevel);
        void PlaceInQueue(int queueSequence);
    }
}