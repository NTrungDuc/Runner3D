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
        GameObject temp = Instantiate(groundTile[(Random.Range(1,groundTile.Length))],nextSpawnPoint,Quaternion.identity);
        temp.transform.parent=transform;
        nextSpawnPoint = temp.transform.GetChild(1).position;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnFirstGround();
    }
    public void RestartGround()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        nextSpawnPoint = Vector3.zero;
        SpawnFirstGround();
    }
    public void SpawnFirstGround()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                GameObject tempFirst = Instantiate(groundTile[0], nextSpawnPoint, Quaternion.identity);
                tempFirst.transform.parent = transform;
                nextSpawnPoint = tempFirst.transform.GetChild(1).position;
            }
            else
            {
                SpawnTile();
            }
        }
    }
}
