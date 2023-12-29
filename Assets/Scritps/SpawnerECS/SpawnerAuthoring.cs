using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

class SpawnerAuthoring : MonoBehaviour
{
    public GameObject entityPrefab;
    public float spawnRate;
    public float spawnRadius;
}

class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new SpawnerData
        {
            entityPrefab = GetEntity(authoring.entityPrefab, TransformUsageFlags.Dynamic),
            spawnPosition = authoring.transform.position,
            nextSpawnTime = 0.0f,
            spawnRate = authoring.spawnRate,
            spawnRadius = authoring.spawnRadius,
        });
    }
}
