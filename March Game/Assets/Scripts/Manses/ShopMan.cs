using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMan : Singleton<ShopMan>
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplaceObjects(GameObject oldObj, GameObject newObj)
    {
        newObj.transform.position = oldObj.transform.position;
        Destroy(oldObj);
    }
}
