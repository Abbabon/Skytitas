using System.Collections.Generic;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IGameSettingsService
    {
        //game object positions settings:
        Vector3 InitialPlayerPosition { get; }
        Vector3 AsteroidsTerminalPosition { get; }
        List<Vector3> AsteroidSpawnPositions { get; }
        
        //general settings:
        float AccelerationSpeedFactor { get; }
        
        //player settings:
        float PlayerSpeed { get; }
        float PlayerMinimumX { get; }
        float PlayerMaximumX { get; }
        
        //aseteroid settings:
        float AsteroidsSpeed { get; }
        float InitialTimeBetweenGenerations { get; }
        float MinimumTimeBetweenGenerations { get; }
    }
}