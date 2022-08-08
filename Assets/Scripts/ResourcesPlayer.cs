using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcesPlayer 
{
    public Dictionary<string,int> resources = new Dictionary<string, int>();
    public void InitializeDictionary()
    {
        resources.Add("Wood",0);
        resources.Add("Stone",0);
        resources.Add("Brick",0);
        resources.Add("Metal",0);
    }

    public void AddResource(string name, int count)
    {
        resources[name] = resources[name] + count;
    }

    public void RemoveResource(string name, int count)
    {
        if (count <= resources[name])
            resources[name] = resources[name] - count;
    }

    public void ViewResource(string name)
    {
        Debug.Log(name + " = " + resources[name]);
    }



}
