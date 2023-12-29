using Unity.Entities;
using UnityEngine;

public class SpeedDataAuthoring: MonoBehaviour
{
    public float speed;

}
public class SpeedDataBaker : Baker<SpeedDataAuthoring>
{
    public override void Bake(SpeedDataAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new SpeedData
        {
            speed = authoring.speed,
        });
    }
}