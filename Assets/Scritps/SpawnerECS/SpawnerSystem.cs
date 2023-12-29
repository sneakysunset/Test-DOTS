using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {

        var job = new SpawnJob()
        {
            elapsedTime = SystemAPI.Time.ElapsedTime
        };
        job.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct SpawnJob : IJobEntity
{
    public double elapsedTime;
    [NativeSetThreadIndex]
    private int threadIndex;
    [BurstCompile]
    public void Execute(ref SpawnerData spawnData)
    {
        if(elapsedTime > spawnData.nextSpawnTime)
        {
            //state.EntityManager.Instantiate(spawnData.entityPrefab);
            spawnData.nextSpawnTime = (float)elapsedTime + spawnData.spawnRate;    
        }
    }
}
