using System;
using UnityEngine;

public class StorageRegulator : MonoBehaviour
{
    [SerializeField] private Storage _firstStorage;
    [SerializeField] private Storage _secondStorage;

    public event Action StoragesLoaded;

    public void DistributeHarvest(Color color)
    {
        if (!_firstStorage.IsLoaded && color == _firstStorage.CurrentColor)
            _firstStorage.AddHarvest();
        else if (!_secondStorage.IsLoaded && color == _secondStorage.CurrentColor)
            _secondStorage.AddHarvest();
        else
            StoragesLoaded?.Invoke();
    }
}