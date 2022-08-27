using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CityData
{
    public int[] cityOne;
    public bool[] cityOneBool;
    public int[] cityTwo;

    public CityData(CityController _curCity)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case ("CIty"):
                cityOne = _curCity.blackBoxesControl;
                cityOneBool = _curCity.isWorking;
                Debug.Log("Deb from CITY in City Data");  
                break;

            case ("Country"):
                cityTwo = _curCity.blackBoxesControl;
                Debug.Log("Deb from Country in City Data");   
                break;
            
            default: 
                Debug.Log("Deb from default in City Data");    
                break;
        }
           

    }
}
