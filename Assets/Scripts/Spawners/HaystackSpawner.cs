using UnityEngine;

public class HaystackSpawner : Spawner<Haystack>
{
    [SerializeField] private ColorChanger _colorChanger;

    public void SpawnHaystack(Transform startPosition, Transform finalPosition, Color color)
    {
        Haystack haystack = Pool.Get();
        _colorChanger.ChangeColor(haystack.gameObject, color);
        SubscribeHaystack(haystack);
        haystack.transform.position = startPosition.position;
        haystack.FlyTo(finalPosition);
    }
    
    protected override void ReleaseObject(Haystack  haystack)
    {
        haystack.Reset();
        haystack.gameObject.SetActive(false);
        Pool.Release(haystack);
        UnsubscribeHaystack(haystack);
    }
    
    private void SubscribeHaystack(Haystack haystack)
    {
        haystack.OnArrived += ReleaseObject;
    }
    
    private void UnsubscribeHaystack(Haystack haystack)
    {
        haystack.OnArrived -= ReleaseObject;
    }
}
