using System.Collections;
using UnityEngine;

public class GrassSpawner : Spawner<Grass>
{
    [SerializeField] private Cutter _bladeCutter;
    [SerializeField] private Transform[] _grassPositions;
    [SerializeField] private float _delayValue = 3f;
    
    private Vector3 _position;
    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_delayValue);
        
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
        yield return _delay; 
        
        Grass newGrass = Pool.Get();    
        newGrass.transform.position = spawnPosition;
    }
}