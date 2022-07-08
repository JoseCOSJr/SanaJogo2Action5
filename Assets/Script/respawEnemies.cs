using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawEnemies : MonoBehaviour
{
    public Text textTimer;
    public GameObject[] enemiesArray;
    private List<GameObject> enemiesAtivedList= new List<GameObject> ();
    private float countTimeRespawEnemie = 0f;
    private int limitCharsInScreem = 3;
    private float timerCount = 100f;
    private loadOtherScene loadOtherSceneX;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesArray.Length; i++)
        {
            GameObject enemy = enemiesArray[i];
            respawObjt.respawObjtStatic.AddRespawList(enemy);
        }
        loadOtherSceneX = GetComponent<loadOtherScene>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerCount > 0f)
        {
            timerCount -= Time.fixedDeltaTime;
            if (timerCount < 0f)
            {
                timerCount = 0f;
            }
            textTimer.text = "" + (int)timerCount;

            if (enemiesAtivedList.Count < limitCharsInScreem)
            {
                if (countTimeRespawEnemie <= 0f)
                {
                    countTimeRespawEnemie = 3f;

                    int numberRespaw = 1;
                    if (timerCount < 25f)
                    {
                        numberRespaw = 4;
                    }
                    else if (timerCount < 50f)
                    {
                        numberRespaw = 3;
                    }
                    else if (timerCount < 75f)
                    {
                        numberRespaw = 2;
                    }

                    for(int i=0; i < numberRespaw; i++)
                    {
                        int id = Random.Range(0, enemiesArray.Length);
                        GameObject objt = respawObjt.respawObjtStatic.GetRespawObjt(enemiesArray[id]);
                        Vector3 posResp = Vector3.zero;
                        posResp.x = -12f - Random.value * 8f;
                        posResp.y = -4.5f;
                        objt.transform.position = posResp;
                        objt.SetActive(true);
                        enemiesAtivedList.Add(objt);
                    }
                   
                    //Debug.Log(objt+" parent "+objt.transform.parent);
                }
                else
                {
                    float mult = 200f / (timerCount + 100f);
                    countTimeRespawEnemie -= Time.fixedDeltaTime * mult;
                }
            }
        }
        else if(!fadeObj.fadeObjInScene.gameObject.activeInHierarchy)
        {
            //Vitória
            loadOtherSceneX.LoadSceneHere();
        }

        if (enemiesAtivedList.Exists(x => !x.activeInHierarchy))
        {
            enemiesAtivedList.RemoveAll(x => !x.activeInHierarchy);
        }
    }
}
