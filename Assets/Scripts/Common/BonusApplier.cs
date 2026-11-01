using UnityEngine;

public class BonusApplier : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private StorageRegulator  _storageRegulator;

    private void OnEnable()
    {
        _collisionHandler.BonusDetected += ApplyBonus;
    }

    private void OnDisable()
    {
        _collisionHandler.BonusDetected -= ApplyBonus;
    }

    private void ApplyBonus(Bonus bonus)
    {
        _storageRegulator.ResetStorages();
    }
}