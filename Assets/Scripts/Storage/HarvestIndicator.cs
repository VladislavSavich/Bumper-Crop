using UnityEngine;

public class HarvestIndicator : MonoBehaviour
{
    [SerializeField] private Harvest[] _harvests;

    private void Start()
    {
        HideHarvests();
    }

    public void ShowHarvests(int count)
    {
        HideHarvests();
        
        for (int i = 0; i < count; i++)
            _harvests[i].gameObject.SetActive(true);
    }
    
    private void HideHarvests()
    {
        foreach (var harvest in _harvests)
            harvest.gameObject.SetActive(false);
    }
}