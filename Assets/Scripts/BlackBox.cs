using System.Collections.Generic;
using UnityEngine;

public class BlackBox : MonoBehaviour
{
    [SerializeField] public List<int> buildingIndex = new List<int>();   // 0,1,2
    [SerializeField] public int[] resourcesToBuild = new int[4];  
    
    [Space]
    [SerializeField] public bool curIsBuild;   
    [SerializeField] public int curBuildIndex;
   
    [Header("Res")]
    [SerializeField] public int people;

    [Header("Ind")]
    [SerializeField] public int peopleWorking;
    [SerializeField] public int[] resourcesPerClick = new int[4];



}
