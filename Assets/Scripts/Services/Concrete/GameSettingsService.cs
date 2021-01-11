using System.Collections.Generic;
using System.Linq;
using Services.Interfaces;
using UnityEngine;

namespace Services.Concrete
{
    public class GameSettingsService : MonoBehaviour, IGameSettingsService 
    {
        [SerializeField] private Transform _initialPlayerTransform;
        [SerializeField] private Transform _asteroidTerminalTransform;
        [SerializeField] private List<Transform> _asteroidSpawnTransforms;

        [SerializeField] private float _accelerationSpeedFactor;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private Transform _playerMinimumTransform;
        [SerializeField] private Transform _playerMaximumTransform;
        [SerializeField] private float _asteroidSpeed;
        [SerializeField] private float _uvScrollBaseSpeed;

        public Vector3 InitialPlayerPosition => _initialPlayerTransform.position;

        public Vector3 AsteroidsTerminalPosition => _asteroidTerminalTransform.position;

        private List<Vector3> _asteroidSpawnPositions;
        public float UVScrollSpeed => _uvScrollBaseSpeed;

        public List<Vector3> AsteroidSpawnPositions
        {
            get
            {
                if (_asteroidSpawnPositions == null)
                {
                    _asteroidSpawnPositions =
                        _asteroidSpawnTransforms.Select(asteroidSpawnPosition => asteroidSpawnPosition.position)
                            .ToList();
                }
                return _asteroidSpawnPositions;
            }
        }

        public float AccelerationSpeedFactor => _accelerationSpeedFactor;
        public float PlayerSpeed => _playerSpeed;
        public float PlayerMinimumX => _playerMinimumTransform.position.x;
        public float PlayerMaximumX => _playerMaximumTransform.position.x;
        public float AsteroidsSpeed => _asteroidSpeed;
    }
}