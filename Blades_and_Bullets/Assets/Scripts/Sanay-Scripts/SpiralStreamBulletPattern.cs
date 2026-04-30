using UnityEngine;

public class SpiralStreamBulletPattern : BaseBulletPattern
{
    [SerializeField] private BulletTypeSO bulletType;
    [SerializeField] private int arms = 2;
    [SerializeField] private float angleStepPerShot = 18f;

    private float currentAngle;

    public override void FirePattern()
    {
        if (bulletSpawner == null || bulletType == null || arms <= 0)
        {
            return;
        }

        float armSpacing = 360f / arms;

        for (int i = 0; i < arms; i++)
        {
            float angle = currentAngle + armSpacing * i;
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.down;

            bulletSpawner.Fire(bulletType, direction);
        }

        currentAngle += angleStepPerShot;
    }
}
