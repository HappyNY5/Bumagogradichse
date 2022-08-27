using UnityEngine;

public class IndScript : MonoBehaviour
{
    [HideInInspector] public int[] resourcesPerClick = new int[4];
    [HideInInspector] public int workers;
    [HideInInspector] public int peopleOnWork;
     public bool indWorking;

    public int level;  
}
