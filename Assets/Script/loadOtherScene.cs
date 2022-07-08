using UnityEngine;
using UnityEngine.SceneManagement;

public class loadOtherScene : MonoBehaviour
{
    public string idSceneGo = "Initial Scene";
    private bool triggerLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerLoad && idSceneGo != "")
        {
            if (fadeObj.fadeObjInScene.FadeEventIsFinish()) 
            {
                SceneManager.LoadSceneAsync(idSceneGo);
                idSceneGo = "";
            }
        }
    }

    public void LoadSceneHere()
    {
        if (!triggerLoad && idSceneGo != "")
        {
            fadeObj.fadeObjInScene.FadeGo(false, 1f);
            triggerLoad = true;
        }
    }
}
