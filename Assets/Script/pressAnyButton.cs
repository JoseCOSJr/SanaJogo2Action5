using UnityEngine;

public class pressAnyButton : MonoBehaviour
{
    private loadOtherScene loadOtherSceneX;

    // Start is called before the first frame update
    void Start()
    {
        loadOtherSceneX = GetComponent<loadOtherScene>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.anyKeyDown && !fadeObj.fadeObjInScene.gameObject.activeInHierarchy)
        {
            loadOtherSceneX.LoadSceneHere();
        }
    }
}
