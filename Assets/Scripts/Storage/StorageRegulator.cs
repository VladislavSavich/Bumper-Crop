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

    public void TryTransferToTruck(Truck truck)
    {
        TransferFromStorage(_firstStorage, truck);
        
        if (truck.IsFull) 
            return;
        
        TransferFromStorage(_secondStorage, truck);
    }
    
    private void TransferFromStorage(Storage storage, Truck  truck)
    {
        if(storage.CurrentColor != truck.CurrentColor)
            return;
        
        if(storage.HarvestCount <= 0)
            return;

        int truckSpace = truck.MaxCapacity - truck.HarvestCount;
        int amountToTransfer = Mathf.Min(storage.HarvestCount, truckSpace);
        
        if (amountToTransfer > 0)
        {
            storage.ExtractHarvest(amountToTransfer);
            truck.AcceptHarvest(amountToTransfer);
        }
    }
}