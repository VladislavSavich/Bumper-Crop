using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : Spawner<Grass>
{
    [SerializeField] private ColorChanger  _colorChanger;
    [SerializeField] private Cutter _bladeCutter;
    [SerializeField] private LandFinder _finder;
    [SerializeField] private float _minDelay = 1f;
    [SerializeField] private float _maxDelay = 3f;

    private WaitForSeconds _delay;
    private Vector3 _position;
    private List<Transform> _landTransforms = new List<Transform>();
    private List<Grass> _activeGrasses = new List<Grass>();

    public void SpawnGrassField()
    {
        _landTransforms.Clear();
        _activeGrasses.Clear();
        
        _finder.CollectGrassPositions(_landTransforms);

        if (_landTransforms.Capacity == 0) 
            return;
        
        foreach (Transform landTransform in _landTransforms)
        {
            Grass grass = Pool.Get();
            _colorChanger.ChangeColor(grass.gameObject);
            grass.gameObject.SetActive(true);
            grass.transform.position = landTransform.position;
            _activeGrasses.Add(grass);
        }
    }

    public void ClearAllGrass()
    {
        StopAllCoroutines();
        
        for (int i = 0; i < _activeGrasses.Count; i++)
        {
            Grass grass = _activeGrasses[i];
            
            if (grass != null)
            {
                ReleaseObject(grass);
            }
        }
        
        _landTransforms.Clear();
        _activeGrasses.Clear();
    }

    private void OnEnable()
    {
        _bladeCutter.GrassReadyToCut += HandleGrassRelease;
    }

    private void OnDisable()
    {
        _bladeCutter.GrassReadyToCut -= HandleGrassRelease;
    }

    private void HandleGrassRelease(Grass grass)
    {
        _activeGrasses.Remove(grass);
        ReleaseObject(grass);
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
        newGrass.gameObject.SetActive(true);
        newGrass.transform.position = spawnPosition;
        _activeGrasses.Add(newGrass);
    }
}