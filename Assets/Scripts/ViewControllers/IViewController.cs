using Entitas;
using UnityEngine;

namespace ViewControllers
{
    public interface IViewController
    {
        Vector3 Position { get; set; }
        Vector3 Scale { get; set; }
        bool Active { get; set; }
        void InitializeView(Contexts contexts, IEntity entity);
        void DestroyView();
    }
}