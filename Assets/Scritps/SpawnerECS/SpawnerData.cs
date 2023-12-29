using Unity.Entities;
using Unity.Mathematics;

public struct SpawnerData : IComponentData
{
    public Entity entityPrefab;
    public float3 spawnPosition;
    public float spawnRadius;
    public float nextSpawnTime;
    public float spawnRate;
}


