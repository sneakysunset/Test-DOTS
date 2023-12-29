using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;


public class TargetDataAuthoring : MonoBehaviour
{
    public float3 target;
}
public class TargetDataBaker : Baker<TargetDataAuthoring>
{
    public override void Bake(TargetDataAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new TargetData
        {
            Target = authoring.target
        });
    }
}