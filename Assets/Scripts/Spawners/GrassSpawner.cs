using System.Collections;
using UnityEngine;

public class GrassSpawner : Spawner<Grass>
{
    [SerializeField] private Cutter _bladeCutter;
    [SerializeField] private Transform[] _grassPositions;
    
    private Vector3 _position;
    
    private void Start()
    {
        foreach (Transform pos in _grassPositions)
        {
            Grass grass = Pool.Get();
            grass.transform.position = pos.position;
        }
    }
    
    private void OnEnable()
    {
        _bladeCutter.GrassReadyToCut += SpawnDelay;
        _bladeCutter.GrassReadyToCut += ReleaseObject;
    }

    private void OnDisable()
    {
        _bladeCutter.GrassReadyToCut -= SpawnDelay;
        _bladeCutter.GrassReadyToCut -= ReleaseObject;
    }

    private void SpawnDelay(Grass grass)
    { 
        StartCoroutine(StartSpawnDelay(grass.transform.position));
    }

    private IEnumerator StartSpawnDelay(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(5f);  
        
        Grass newGrass = Pool.Get();    
        newGrass.transform.position = spawnPosition;
    }
}