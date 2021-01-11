using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Interfaces;

namespace Components.MetaComponents
{
    [Meta, Unique]
    public class GameSettingsComponent : IComponent
    {
        public IGameSettingsService instance;
    }
}