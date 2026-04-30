using UnityEngine;

public class FlowerBurstBulletPattern : BaseBulletPattern
{
    [SerializeField] private BulletTypeSO bulletType;
    [SerializeField] private int petals = 6;
    [SerializeField] private int bulletsPerPetal = 3;
    [SerializeField] private float petalSpreadAngle = 18f;
    [SerializeField] private float angleOffsetPerShot = 8f;

    private float currentAngleOffset;

    public override void FirePattern()
    {
        if (bulletSpawner == null || bulletType == null || petals <= 0 || bulletsPerPetal <= 0)
        {
            return;
        }

        float petalSpacing = 360f / petals;

        for (int petal = 0; petal < petals; petal++)
        {
            float centerAngle = currentAngleOffset + petalSpacing * petal;
            float startAngle = centerAngle - petalSpreadAngle * 0.5f;
            float step = bulletsPerPetal > 1 ? petalSpreadAngle / (bulletsPerPetal - 1) : 0f;

            for (int i = 0; i < bulletsPerPetal; i++)
            {
                float angle = startAngle + step * i;
                Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.down;

                bulletSpawner.Fire(bulletType, direction);
            }
        }

        currentAngleOffset += angleOffsetPerShot;
    }
}
