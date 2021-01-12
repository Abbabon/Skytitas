using UnityEngine;
using Zenject;

namespace Views.Concrete
{
    public class AsteroidView : MonoBehaviour
    {
        public class Pool : MemoryPool<AsteroidView>
        {
            protected override void OnCreated(AsteroidView item)
            {
                item.gameObject.SetActive(false);
            }

            protected override void OnDespawned(AsteroidView item)
            {
                item.gameObject.SetActive(false);
            }

            protected override void OnSpawned(AsteroidView item)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}