using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundTile : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        GroundSpawner.Instance.SpawnTile();
        Destroy(gameObject, 2);
    }
}
