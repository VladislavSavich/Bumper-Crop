using UnityEngine;

public class HarvestIndicator : MonoBehaviour
{
    [SerializeField] private Harvest[] _harvests;
    [SerializeField] private ColorChanger  _colorChanger;
    [SerializeField] private Color _harvestColor;
    
    private void Start()
    {
        HideHarvests();
    }

    public void ShowHarvests(int count)
    {
        HideHarvests();

        for (int i = 0; i < count; i++)
        {
            _harvests[i].gameObject.SetActive(true);
            _colorChanger.ChangeColor(_harvests[i].gameObject);
        }
    }
    
    private void HideHarvests()
    {
        foreach (var harvest in _harvests)
            harvest.gameObject.SetActive(false);
    }
}