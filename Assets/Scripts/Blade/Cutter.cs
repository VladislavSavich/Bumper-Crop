using System;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public event Action<Grass> GrassReadyToCut;
    public event Action GrassCuttered;
    
    public void CutGrass(Grass grass)
    {
        if (grass == null)
            return;
        
        GrassReadyToCut?.Invoke(grass);
        GrassCuttered?.Invoke();
    }
}