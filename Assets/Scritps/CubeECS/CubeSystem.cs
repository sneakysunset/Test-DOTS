using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

public partial struct CubeSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var job = new CubeJob()
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };
        job.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct CubeJob : IJobEntity
{
    public float deltaTime;

    [BurstCompile]
    public void Execute(ref CubeData cubeData, ref LocalTransform transform)
    {
        transform = transform.RotateY(math.radians(cubeData.speed * deltaTime));
    }
}


/*public partial class CubeSystem : SystemBase
{
    [BurstCompile]
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (cubeData, transform) in SystemAPI.Query<RefRO<CubeData>, RefRW<LocalTransform>>())
        {
            transform.ValueRW = transform.ValueRO.RotateY(math.radians(cubeData.ValueRO.speed * deltaTime));
        }
    }
}*/
