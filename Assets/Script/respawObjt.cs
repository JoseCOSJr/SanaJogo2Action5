using System.Collections.Generic;
using UnityEngine;

public class respawObjt : MonoBehaviour
{
    public static respawObjt respawObjtStatic = null;
    private List<GameObject> objtList= new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        respawObjtStatic = this;
    }

    public bool ExistThisObjt(GameObject objt)
    {
        return objtList.Exists(x => x.name == objt.name);
    }

    public void AddRespawList(GameObject objt, int copies = 10)
    {
        for(int i = 0; i < copies; i++)
        {
            GameObject objtX = Instantiate(objt);
            objtX.name = objt.name;
            objtX.transform.SetParent(transform);
            objtX.SetActive(false);
            objtList.Add(objtX);
        }
    }

    public GameObject GetRespawObjt(GameObject objt)
    {
        GameObject objtX = objtList.Find(x => x.name == objt.name && !x.activeInHierarchy);

        if (!objtX)
        {
            AddRespawList(objt);
            objtX = objtList.Find(x => x.name == objt.name && !x.activeInHierarchy);
        }

        return objtX;
    }
}
