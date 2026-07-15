using System.Collections;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    [Header("Prefabs")]
    public GameObject[] collectiblePrefabs;
    public GameObject[] trapPrefabs;

    [Header("Lane Ayarları")]
    public float laneDistance = 3f;

    [Header("Yükseklik Ayarları")]
    public float collectibleYPosition = 0.5f;

    [Header("Zamanlama")]
    public float waveInterval = 1.5f;
    public float distanceBetweenWaves = 10f;

    [Range(0f, 1f)]
    public float trapChancePerLane = 0.4f;

    private bool gameStarted = false;
    private float nextSpawnZ = 20f;

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.T))
        {
            gameStarted = true;
            StartCoroutine(SpawnLoop());
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (gameStarted)
        {
            SpawnWave(nextSpawnZ);
            nextSpawnZ += distanceBetweenWaves;

            float delay = waveInterval * (5f / playerMovement.moveSpeed);

            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnWave(float zPos)
    {
        for (int lane = -1; lane <= 1; lane++)
        {
            float xPos = lane * laneDistance;

            GameObject prefabToSpawn = ChoosePrefabForLane(out bool isTrap);
            
            float yPos = isTrap ? 0f : collectibleYPosition;
            Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

            if (prefabToSpawn != null)
            {
                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            }
        }
    }

    private GameObject ChoosePrefabForLane(out bool isTrap)
    {
        isTrap = Random.value < trapChancePerLane;
        if (isTrap)
            return trapPrefabs[Random.Range(0, trapPrefabs.Length)];
        else
            return collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];
    }
}
