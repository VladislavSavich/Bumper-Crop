using System.Collections;
using UnityEngine;

public class BonusSpawner : Spawner<Bonus>
{
    [SerializeField] private CollisionHandler  _collisionHandler;
    [SerializeField] private float _minDelay = 1f;
    [SerializeField] private float _maxDelay = 3f;
    
    private WaitForSeconds _delay;
    private Vector3 _position;

    private void Start()
    {
        SpawnDelay();
    }
    
    private void OnEnable()
    {
        _collisionHandler.BonusDetected += ReleaseObject;
    }

    private void OnDisable()
    {
        _collisionHandler.BonusDetected -= ReleaseObject;
    }

    private void SpawnDelay()
    { 
        StartCoroutine(StartSpawnDelay());
    }
    
    private WaitForSeconds GenerateDelay()
    {
        _delay  = new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        
        return _delay;
    }
    
    private IEnumerator StartSpawnDelay()
    {
        while (enabled)
        {
            _position = _collisionHandler.transform.position;
        
            yield return GenerateDelay();
        
            Bonus newBonus = Pool.Get();
            newBonus.transform.position = _position;
        }
    }
}
