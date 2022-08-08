using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{   
    [SerializeField] private List<GameObject> buildings = new List<GameObject>();
    [SerializeField] private GameObject builderChoiser_GO;
    [SerializeField] private PlayerController playerControllerScr;

    public void CreateBuilderChoiser(Transform builder)
    {
        Vector3 posForBuilderChoise = builder.transform.position + Vector3.up * 70;
        GameObject builderChoiser = Instantiate(builderChoiser_GO, posForBuilderChoise, Quaternion.Euler(0,0,0));
        
        playerControllerScr.objOnDestroy.Add(builderChoiser);
        // Debug.Log(playerControllerScr.objOnDestroy.Count);

        Transform builderChoiserStol = builderChoiser.transform.GetChild(0).transform;
        
        builderChoiserStol.localScale = new Vector3(2+buildings.Count, 0.5f, 3f);
        
        builderChoiser.GetComponent<Rigidbody>().AddForce(Vector3.down * 300000f);
    }

    public void CreateBuilderBlocks(Transform builder)
    {
        int curBuindingNumber = 0;
        Vector3[] curPosBlock = new Vector3[3];
            
        switch (buildings.Count)
        {
            case 1:
            curPosBlock[0] = new Vector3( 0, 85, 0);
            break;
            
            case 2:
            curPosBlock[0] = new Vector3( -2f, 85, 0);
            curPosBlock[1] = new Vector3( 2f, 85, 0);
            break;

            case 3:
            curPosBlock[0] = new Vector3( 0, 85, 0);   
            curPosBlock[1] = new Vector3( -3.75f, 85, 0);
            curPosBlock[2] = new Vector3( 3.75f, 85, 0);        
            break;
            
            default:
            curPosBlock[0] = new Vector3(0,0,0);
            break;
        }
        
        
        foreach(GameObject building in buildings)
        {
            Vector3 posForBuilderBlock = builder.transform.position + curPosBlock[curBuindingNumber];

            GameObject builderBlock = Instantiate(building, posForBuilderBlock, Quaternion.Euler(0,0,0));
            playerControllerScr.objOnDestroy.Add(builderBlock);
            
            builderBlock.name = (curBuindingNumber).ToString();
            builderBlock.GetComponent<Rigidbody>().AddForce(Vector3.down * 10000f);  //SPEED block

            curBuindingNumber++;
        }
    }
}
