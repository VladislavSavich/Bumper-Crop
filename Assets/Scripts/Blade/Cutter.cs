using UnityEngine;

public class Cutter : MonoBehaviour
{
    public void CutGrass(Grass grass)
    {
        Destroy(grass.gameObject);
    }
}
