using Services.Interfaces;

namespace Bootstrap
{
    public class GameServices
    {
        public readonly IInputService InputService;
        public readonly IViewService ViewService;

        public GameServices(IInputService inputService, IViewService viewService)
        {
            InputService = inputService;
            ViewService = viewService;
        }
    }
}