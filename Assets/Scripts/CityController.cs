using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityController : MonoBehaviour
{
    [SerializeField] public List<BlackBox> blackBoxes;
    [SerializeField] private List<GameObject> buildingTextures;
    public int[] blackBoxesControl;
    public bool[] isWorking;

    public void UpdateMap()
    {
        int i = 0;

        while (true & (SceneManager.GetActiveScene().name != "Country"))
        {
            foreach (BlackBox blackBox in blackBoxes)
            {
                blackBox.curBuildIndex = blackBoxesControl[i];    
                
                if(blackBoxesControl[i] != 0)
                {
                    Build(blackBoxesControl[i],blackBox, i, isWorking[i]);
                }
                i++;
            }

            if (i == blackBoxes.Count) break;
        } 
    }

    private void Build(int _numb, BlackBox _blackBox, int i, bool _isWorking)
    {
        

        _blackBox.gameObject.active = true;
        _blackBox.curIsBuild = true;
        // Debug.Log(playerManagerScript.selectedBlackBox);

        float buildingRotY = _blackBox.gameObject.transform.eulerAngles.y;
        Vector3 curRot = new Vector3(90, 0, buildingRotY);

        Vector3 buildPos = _blackBox.gameObject.transform.position;
        Vector3 curPos = buildPos + new Vector3(0, 70, 0);

        int index = (_numb%100)/10;
        GameObject building = Instantiate(buildingTextures[index], curPos, Quaternion.Euler(curRot), _blackBox.transform);
        
        _blackBox.transform.GetComponent<BoxCollider>().enabled = false;


        Debug.Log(_isWorking);
        // building.GetComponent<IndScript>().indWorking = _isWorking;

        string buildName = "Building" + i;
        building.name = buildName;

        building.GetComponent<Rigidbody>().AddForce(Vector3.down * 50000f);  

        if (building.layer == 18) //Ind
        {              
            building.GetComponent<IndScript>().resourcesPerClick = _blackBox.resourcesPerClick;
            building.GetComponent<IndScript>().workers = _blackBox.peopleWorking;

            if(_isWorking)
            {
                _blackBox.isWorking = _isWorking;
                building.GetComponent<IndScript>().indWorking = _isWorking;
                building.GetComponent<IndScript>().peopleOnWork = building.GetComponent<IndScript>().workers;
            }
        } 
    }

    public void ChangeConntrol()
    {
        int i = 0;
        blackBoxesControl = new int[blackBoxes.Count];
        isWorking = new bool[blackBoxes.Count];

        while (true & (SceneManager.GetActiveScene().name != "Country"))
        {
            foreach (BlackBox blackBox in blackBoxes)
            {
                blackBoxesControl[i] = blackBox.curBuildIndex;    //передаём в городской массив значения поблочно
                isWorking[i] = blackBox.isWorking;
                i++;
            }

            if (i == blackBoxes.Count) break;
        }            
    }

}
