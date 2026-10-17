using System.Collections;
using UnityEngine;

public class GrassSpawner : Spawner<Grass>
{
    [SerializeField] private ColorChanger  _colorChanger;
    [SerializeField] private Cutter _bladeCutter;
    [SerializeField] private Transform[] _grassPositions;
    [SerializeField] private float _minDelay = 1f;
    [SerializeField] private float _maxDelay = 3f;

    private WaitForSeconds _delay;
    private Vector3 _position;

    private void Start()
    {
        foreach (Transform pos in _grassPositions)
        {
            Grass grass = Pool.Get();
            _colorChanger.ChangeColor(grass.gameObject);
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

    private WaitForSeconds GenerateDelay()
    {
        _delay  = new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        
        return _delay;
    }

    private IEnumerator StartSpawnDelay(Vector3 spawnPosition)
    {
        yield return GenerateDelay();
        
        Grass newGrass = Pool.Get();
        _colorChanger.ChangeColor(newGrass.gameObject);
        newGrass.transform.position = spawnPosition;
    }
}