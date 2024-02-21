using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    private static GroundSpawner instance;
    public static GroundSpawner Instance { get => instance; }
    [SerializeField] private GameObject[] groundTile;
    Vector3 nextSpawnPoint;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile[(Random.Range(0,groundTile.Length))],nextSpawnPoint,Quaternion.identity);
        temp.transform.parent=transform;
        nextSpawnPoint = temp.transform.GetChild(1).position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }
    public void RestartGround()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        nextSpawnPoint = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }
}
