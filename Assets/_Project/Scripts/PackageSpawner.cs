using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    [Header("Prefab & số lượng")]
    [SerializeField] GameObject packagePrefab;
    [SerializeField] int maxPackages = 3;          // tối đa bao nhiêu gói cùng lúc trên map
    [SerializeField] float spawnInterval = 3f;     // giây giữa mỗi lần thử spawn

    [Header("Vùng spawn (tọa độ world)")]
    [SerializeField] Vector2 areaMin = new Vector2(-10f, -10f);
    [SerializeField] Vector2 areaMax = new Vector2(10f, 10f);

    [Header("Tránh spawn đè lên vật cản")]
    [SerializeField] LayerMask blockedLayers;      // layer của nhà, cây, tường...
    [SerializeField] float checkRadius = 0.5f;

    float timer;

    void Start()
    {
        // Spawn sẵn đủ số gói lúc bắt đầu game
        for (int i = 0; i < maxPackages; i++)
            TrySpawn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < spawnInterval) return;
        timer = 0f;

        // Đếm số gói còn trên map, chưa đủ thì spawn thêm
        if (GameObject.FindGameObjectsWithTag("Package").Length < maxPackages)
            TrySpawn();
    }

    void TrySpawn()
    {
        // Thử tối đa 30 lần để tìm một vị trí trống
        for (int i = 0; i < 30; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y));

            if (Physics2D.OverlapCircle(pos, checkRadius, blockedLayers) == null)
            {
                Instantiate(packagePrefab, pos, Quaternion.identity);
                return;
            }
        }
        Debug.LogWarning("Không tìm được vị trí trống để spawn gói.");
    }

    // Vẽ khung vùng spawn trong Scene view để dễ chỉnh
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 center = (areaMin + areaMax) / 2f;
        Vector2 size = areaMax - areaMin;
        Gizmos.DrawWireCube(center, size);
    }
}

