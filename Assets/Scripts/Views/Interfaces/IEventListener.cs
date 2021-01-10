using Entitas;

namespace Views.Interfaces
{
    public interface IEventListener
    {
        void RegisterListeners(IEntity entity);       
    }
}