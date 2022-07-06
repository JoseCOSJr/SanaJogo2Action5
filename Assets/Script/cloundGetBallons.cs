using UnityEngine;
using UnityEngine.SceneManagement;

public class cloundGetBallons : MonoBehaviour
{
    public Vector3 posF = new Vector3(0f, -2f, 0f);
    private Vector3 pos0, posAuxI, posAuxF;
    public int maxBallons = 12;
    private int countBallons = 0;
    private float timeMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        pos0 = transform.position;
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
        if (collision.gameObject.CompareTag("Ballons") && countBallons < maxBallons)
        {
            countBallons += 1;
            timeMove = 1f;
            posAuxI = transform.position;
            posAuxF = Vector3.Lerp(pos0, posF, (1f * countBallons) / maxBallons);
            collision.gameObject.SetActive(false);

            if (countBallons >= maxBallons)
            {
                //Game Over
                SceneManager.LoadSceneAsync("Game Over Scene");
            }
        }
    }
}
