using System;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public event Action GrassCuttered;
    
    public void CutGrass(Grass grass)
    {
        if (grass == null)
            return;
        
        Destroy(grass.gameObject);
        GrassCuttered?.Invoke();
    }
}