using UnityEngine;

public class enemieMove : MonoBehaviour
{
    public static float speedShoot = 1f;
    [SerializeField]
    private float velocity = 3f;
    private float countRespawTime;
    private int coutRespawBallons;
    [SerializeField]
    [Min(1)]
    private int ballowsCanRespaw = 2;
    public GameObject respawTalk;
    public Transform posRespaw;
    
    private int countrespaw;
    // Start is called before the first frame update
    void Awake()
    {
        if (respawObjt.respawObjtStatic.ExistThisObjt(respawTalk))
        {
            respawObjt.respawObjtStatic.AddRespawList(respawTalk, 30);
        }
    }

    private void OnEnable()
    {
        countRespawTime = Random.value * 1f + 1f;
        coutRespawBallons = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 15f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector3.right * velocity * Time.fixedDeltaTime);
        }

        if (coutRespawBallons < ballowsCanRespaw && transform.position.x <= 5f && transform.position.x >= -10)
        {
            if (countRespawTime <= 0f)
            {
                coutRespawBallons++;
                countRespawTime = Random.value * 1f + 1f;
                GameObject objt = respawObjt.respawObjtStatic.GetRespawObjt(respawTalk);
                objt.SetActive(true);
                objt.transform.position = posRespaw.transform.position;
            }
            else
            {
                countRespawTime -= Time.fixedDeltaTime;
            }
        }
    }
}
