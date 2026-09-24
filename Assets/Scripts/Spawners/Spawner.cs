using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int PoolCapacity = 25;
    [SerializeField] protected int PoolMaxSize = 50;

    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => Instantiate(Prefab),
            actionOnGet: ActionOnGet,
            actionOnRelease: ActionOnRelease,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: PoolCapacity,
            maxSize: PoolMaxSize);
    }

    protected virtual void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void ReleaseObject(T obj)
    {
        if (obj == null)
            return;
        
        Pool.Release(obj);
    }
}