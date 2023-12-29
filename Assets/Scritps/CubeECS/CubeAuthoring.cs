using Unity.Entities;
using UnityEngine;

public class CubeAuthoring : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Random.Range(0, speed);
    }
    public class CubeBaker : Baker<CubeAuthoring>
    {
        public override void Bake(CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new CubeData
            {
                speed = authoring.speed
            });
        }
    }
}
