using System.Collections.Generic;
using UnityEngine;

public class BlackBox : MonoBehaviour
{
    [SerializeField] public List<GameObject> buildingsBlocks = new List<GameObject>();
    [SerializeField] public int[] resourcesToBuild = new int[4];
   
    [Header("Res")]
    [SerializeField] public int people;

    [Header("Ind")]
    [SerializeField] public int peopleWorking;
    [SerializeField] public int[] resourcesPerClick = new int[4];
}
