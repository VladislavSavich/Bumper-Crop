using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int PoolCapacity = 8;
    [SerializeField] protected int PoolMaxSize = 8;

    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => Instantiate(Prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj),
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
        Pool.Release(obj);
    }
}