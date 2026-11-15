using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : Spawner<Bonus>
{
    [SerializeField] private CollisionHandler  _collisionHandler;
    [SerializeField] private float _minDelay = 1f;
    [SerializeField] private float _maxDelay = 3f;
    
    private WaitForSeconds _delay;
    private Vector3 _position;
    private List<Bonus> _activeBonuses = new List<Bonus>();
    
    private void OnEnable()
    {
        _collisionHandler.BonusDetected += HandleBonusRelease;
    }

    private void OnDisable()
    {
        _collisionHandler.BonusDetected -= HandleBonusRelease;
    }

    public void SpawnDelay()
    { 
        StartCoroutine(StartSpawnDelay());
    }
    
    public void ClearAllBonus()
    {
        StopAllCoroutines();
        
        for (int i = 0; i < _activeBonuses.Count; i++)
        {
            Bonus bonus = _activeBonuses[i];
            
            if (bonus != null)
            {
                ReleaseObject(bonus);
            }
        }
        
        _activeBonuses.Clear();
    }
    
    private void HandleBonusRelease(Bonus bonus)
    {
        _activeBonuses.Remove(bonus);
        ReleaseObject(bonus);
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
            _activeBonuses.Add(newBonus);
        }
    }
}
