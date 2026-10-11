using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Grass : MonoBehaviour
{
    private Renderer  _renderer;

    public Color CurrentColor => _renderer.material.color;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}