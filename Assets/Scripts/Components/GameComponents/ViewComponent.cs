using Entitas;
using UnityEngine;

namespace Components.GameComponents
{
    [Game]
    public class ViewComponent : IComponent
    {
        public GameObject Value;
    }
}