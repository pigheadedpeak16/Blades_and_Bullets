using UnityEngine;

public class BulletSpawnerDemoSetup : MonoBehaviour
{
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private BulletPool bulletPool;

    private void Awake()
    {
        if (bulletSpawner != null && bulletPool != null)
        {
            bulletSpawner.Init(bulletPool);
        }
    }
}
