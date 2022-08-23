using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityController : MonoBehaviour
{
    [SerializeField] public List<BlackBox> blackBoxes;
    [SerializeField] private List<GameObject> buildingTextures;
    public int[] blackBoxesControl;

    public void UpdateMap()
    {
        int i = 0;

        while (true & (SceneManager.GetActiveScene().name != "Country"))
        {
            foreach (BlackBox blackBox in blackBoxes)
            {
                blackBox.curBuildIndex = blackBoxesControl[i];    //передаём в городской массив значения поблочно
                
                if(blackBoxesControl[i] != 0)
                {
                    Build(blackBoxesControl[i],blackBox);
                }
                i++;
            }

            if (i == blackBoxes.Count) break;
        } 
    }

    private void Build(int _numb, BlackBox _blackBox)
    {
        _blackBox.gameObject.active = false;
        _blackBox.curIsBuild = true;
        // Debug.Log(playerManagerScript.selectedBlackBox);

        float buildingRotY = _blackBox.gameObject.transform.eulerAngles.y;
        Vector3 curRot = new Vector3(90, 0, buildingRotY);

        Vector3 buildPos = _blackBox.gameObject.transform.position;
        Vector3 curPos = buildPos + new Vector3(0, 70, 0);

        //Передать 2 текстуры, и выбирать одну из них 
        int index = (_numb%100)/10;
        GameObject building = Instantiate(buildingTextures[index], curPos, Quaternion.Euler(curRot));
        
        building.GetComponent<Rigidbody>().AddForce(Vector3.down * 50000f);   
    }

    public void ChangeConntrol()
    {
        int i = 0;
        blackBoxesControl = new int[blackBoxes.Count];

        while (true & (SceneManager.GetActiveScene().name != "Country"))
        {
            foreach (BlackBox blackBox in blackBoxes)
            {
                blackBoxesControl[i] = blackBox.curBuildIndex;    //передаём в городской массив значения поблочно
                i++;
            }

            if (i == blackBoxes.Count) break;
        }            
    }

}
