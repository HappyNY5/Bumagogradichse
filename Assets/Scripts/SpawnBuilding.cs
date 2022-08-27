using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    private PlayerManager playerManagerScript;
    private CityController cityControllerScript;
    [SerializeField] private GameObject buildingTextures;
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerManagerScript = player.GetComponent<PlayerManager>();
        cityControllerScript = player.GetComponent<CityController>();
    }

    public void Spawn()
    {
        if (playerManagerScript.ResourcesIsEnought(playerManagerScript.selectedBlackBox))
        {
            playerManagerScript.ChangePlayerResources(playerManagerScript.selectedBlackBox.GetComponent<BlackBox>().resourcesToBuild, false);

            playerManagerScript.selectedBlackBox.active = true;
            playerManagerScript.selectedBlackBox.GetComponent<BoxCollider>().enabled = false;
            playerManagerScript.selectedBlackBox.GetComponent<BlackBox>().curIsBuild = true;
            Debug.Log(playerManagerScript.selectedBlackBox);

            float buildingRotY = playerManagerScript.selectedBlackBox.transform.eulerAngles.y;
            Vector3 curRot = new Vector3(90, 0, buildingRotY);

            Vector3 buildPos = playerManagerScript.selectedBlackBox.transform.position;
            Vector3 curPos = buildPos + new Vector3(0, 70, 0);

            GameObject building = Instantiate(buildingTextures, curPos, Quaternion.Euler(curRot), playerManagerScript.selectedBlackBox.transform);
            
            

            int indexOfBlackBox = int.Parse((playerManagerScript.selectedBlackBox.name).Substring(13));
            
            string buildName = "Building" + indexOfBlackBox;
            building.name = buildName;
            building.GetComponent<Rigidbody>().AddForce(Vector3.down * 50000f);            //Build Create speed
            

            if (building.layer == 16) //Res
            {
                playerManagerScript.peopleAll = playerManagerScript.peopleAll + playerManagerScript.selectedBlackBox.GetComponent<BlackBox>().people;
                cityControllerScript.blackBoxes[indexOfBlackBox].curBuildIndex = 101;
            }
            
            if (building.layer == 18) //Ind
            {
                cityControllerScript.blackBoxes[indexOfBlackBox].curBuildIndex = 111;

                
                building.GetComponent<IndScript>().resourcesPerClick = playerManagerScript.selectedBlackBox.GetComponent<BlackBox>().resourcesPerClick;
                building.GetComponent<IndScript>().workers = playerManagerScript.selectedBlackBox.GetComponent<BlackBox>().peopleWorking;
            }

            
            playerManagerScript.DeleteObj();
        }
    }

    
}
