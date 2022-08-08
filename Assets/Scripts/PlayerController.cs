using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private List<GameObject> buildings = new List<GameObject>(3);
    [SerializeField] private ResourcesPlayer resourcesPlayer = new ResourcesPlayer();


    [HideInInspector] public List<GameObject> objOnDestroy = new List<GameObject>();
    
    private CreateBuilding createBuildingScr = new CreateBuilding();
    private GameObject curObject;
    private Vector3 buildPos;
    private int layerCurObject;
    private float buildingRotY = 0f;
    private string curObjectTag;
    private bool builderBlockCreated = false;


    void Awake()
    {
        resourcesPlayer.InitializeDictionary();
    }

    
    void Update()
    {
        Ray mouseRay = mainCam.ScreenPointToRay(Input.mousePosition);                   //Ray from mouse
        if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue, groundLayer)) //
        {
            Vector3 curPosPlayer = new Vector3(hit.point.x, hit.point.y, hit.point.z);             
            transform.position = curPosPlayer;                                          //change obj pos
        }

        switch (layerCurObject)
        {
            case 10:                        //Ground
                break;
            
            case 13:                        //BuildingPoint
                if (Input.GetMouseButtonDown(0))
                {
                    builderBlockCreated = true;
                    buildingRotY = curObject.transform.eulerAngles.y;
                    buildPos = curObject.transform.position;
                    // Debug.Log(curObject.transform.eulerAngles.y);

                    createBuildingScr.CreateBuilderChoiser(curObject.transform);
                    createBuildingScr.CreateBuilderBlocks(curObject.transform);

                    curObject.active = false;
                }
                break;
            
            case 15:                        //Building
                if (Input.GetMouseButtonDown(0))
                { 
                    Vector3 curRot = new Vector3(90,0,buildingRotY);
                    Vector3 curPos = buildPos + new Vector3(0,70,0);

                    // curObject.GetComponent<Rigidbody>().AddForce(transform.up * 10000f);
                    
                    GameObject building = Instantiate(buildings[int.Parse(curObjectTag)], curPos, Quaternion.Euler(curRot));
                    building.GetComponent<Rigidbody>().AddForce(Vector3.down * 50000f);            //Build Create speed
                    
                    Destroy(curObject, 6f);

                    foreach(GameObject obj in objOnDestroy)
                    {
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        obj.GetComponent<Rigidbody>().AddForce(Vector3.down * 50000f);
                        Destroy(obj, 4f);
                    }

                    objOnDestroy.Clear();
                }
                break;
            
            default:
                break;
        }
    }
    
    
    private void OnTriggerEnter(Collider other) 
    {
        layerCurObject = other.gameObject.layer;
        curObject  = other.gameObject;
        curObjectTag = other.tag;

        createBuildingScr = other.GetComponent<CreateBuilding>();
    }
}
