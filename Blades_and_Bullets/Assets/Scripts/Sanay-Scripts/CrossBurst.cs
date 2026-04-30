using UnityEngine;

public class CrossBurstBulletPattern : BaseBulletPattern
{
    [SerializeField] private BulletTypeSO bulletType;
    [SerializeField] private float angleOffsetPerShot = 15f;

    private float currentAngleOffset;

    public override void FirePattern()
    {
        if (bulletSpawner == null || bulletType == null)
        {
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            float angle = currentAngleOffset + i * 90f;
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.down;

            bulletSpawner.Fire(bulletType, direction);
        }

        currentAngleOffset += angleOffsetPerShot;
    }
}
