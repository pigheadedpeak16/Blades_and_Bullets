using UnityEngine;

public class RingBurstBulletPattern : BaseBulletPattern
{
    [SerializeField] private int bulletCount = 12;
    [SerializeField] private float angleOffsetPerShot = 10f;
    [SerializeField] private BulletTypeSO bulletType;

    private float currentAngleOffset;

    public override void FirePattern()
    {
        if (bulletSpawner == null || bulletType == null || bulletCount <= 0)
        {
            return;
        }

        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = currentAngleOffset + angleStep * i;
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.down;

            bulletSpawner.Fire(bulletType, direction);
        }

        currentAngleOffset += angleOffsetPerShot;
    }
}
