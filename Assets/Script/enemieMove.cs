using UnityEngine;

public class enemieMove : MonoBehaviour
{
    public static float speedShoot = 1f;
    private float velocity = 5f;
    private float countRespaw = 0f;
    public GameObject respawTalk;
    public Transform posRespaw;
    private bool triggerIsRespaw = false;
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
        velocity = 4f + 2f * Random.value;
        countRespaw = Random.value * 1f + 1f;
        triggerIsRespaw = false;
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

        if (!triggerIsRespaw && transform.position.x <= 5f && transform.position.x >= -10)
        {
            if (countRespaw <= 0f)
            {
                triggerIsRespaw = true;
                GameObject objt = respawObjt.respawObjtStatic.GetRespawObjt(respawTalk);
                objt.SetActive(true);
                objt.transform.position = posRespaw.transform.position;
            }
            else
            {
                countRespaw -= Time.fixedDeltaTime;
            }
        }
    }
}
