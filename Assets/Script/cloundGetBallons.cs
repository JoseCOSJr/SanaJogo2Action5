using UnityEngine;
using UnityEngine.SceneManagement;

public class cloundGetBallons : MonoBehaviour
{
    public Vector3 posF = new Vector3(0f, 0f, 0f);
    private Vector3 pos0, posAuxI, posAuxF;
    private int maxBallons = 24;
    private int countBallonsPoints = 0;
    private float timeMove = 0f;
    private loadOtherScene loadOtherSceneX;

    // Start is called before the first frame update
    void Start()
    {
        pos0 = transform.position;
        loadOtherSceneX = GetComponent<loadOtherScene>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timeMove > 0f)
        {
            timeMove -= Time.fixedDeltaTime * 2f;
            Vector3 posAux = Vector3.Lerp(posAuxF, posAuxI, timeMove);
            transform.position = posAux;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        progetilHit progetilHit = collision.GetComponent<progetilHit>();

        if (progetilHit && countBallonsPoints < maxBallons && !fadeObj.fadeObjInScene.gameObject.activeInHierarchy)
        {
            countBallonsPoints += progetilHit.pointsValue;
            if (countBallonsPoints >= maxBallons)
            {
                countBallonsPoints = maxBallons;
                //Game Over
                loadOtherSceneX.LoadSceneHere();
            }
            timeMove = 1f;
            posAuxI = transform.position;
            posAuxF = Vector3.Lerp(pos0, posF, (1f * countBallonsPoints) / maxBallons);
            collision.gameObject.SetActive(false);
        }
    }
}
