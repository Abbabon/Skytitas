using Entitas;
using ViewControllers;

namespace Components.GameComponents
{
    [Game]
    public class ViewComponent : IComponent
    {
        public IViewController instance;
    }
}