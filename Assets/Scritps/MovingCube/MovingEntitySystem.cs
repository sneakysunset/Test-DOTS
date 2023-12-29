using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct MovingEntitySystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        
        foreach ((RefRW<LocalTransform> transform, RefRO <SpeedData> speedD) in 
            SystemAPI.Query <RefRW<LocalTransform>, RefRO<SpeedData>>())
        {
            foreach((RefRO<TargetData> targetD, RefRO<LocalTransform> targetTransform) in SystemAPI.Query<RefRO<TargetData>, RefRO<LocalTransform>>())
            {
                float3 direction =  targetTransform.ValueRO.Position - transform.ValueRO.Position;
                direction.y = transform.ValueRO.Position.y;
                transform.ValueRW.Position += direction * speedD.ValueRO.speed * SystemAPI.Time.DeltaTime;
            }
        }
    }
}
