using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Views.Concrete
{
    public class ShipView : MonoBehaviour
    {
        //TODO: tags service...
        private const string ASTEROID_TAG = "Asteroid";

        [SerializeField] private ParticleSystem _explostionParticleSystem;
        
        private ICollisionService _collisionService;
        
        [Inject]
        private void Initialize(ICollisionService collisionService)
        {
            _collisionService = collisionService;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ASTEROID_TAG))
            {
                _explostionParticleSystem.Play();

                var asteroidView = other.gameObject.GetComponent<AsteroidView>();
                _collisionService.PlayerCollidedWithAsteroid(asteroidView.Entity);
            }
        }
        
        public class Factory : PlaceholderFactory<ShipView>
        {
            
        }
    }
}