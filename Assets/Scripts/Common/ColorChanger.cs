using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Color _defaultColor;

    public void ChangeColor(GameObject model)
    {
        if (model == null)
            return;

        if (model.TryGetComponent(out Renderer objectRenderer))
            objectRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        if (_colors == null || _colors.Length == 0)
            return _defaultColor;
        
        return _colors[Random.Range(0, _colors.Length)];
    }
}