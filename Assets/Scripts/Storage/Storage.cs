using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private HarvestCounter  _counter;
    [SerializeField] private HarvestIndicator _indicator;

    private void OnEnable()
    {
        _counter.CountChanged += _indicator.ShowHarvests;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= _indicator.ShowHarvests;
    }
    
    public void AddHarvest()
    {
        _counter.AddCount();
    }
}