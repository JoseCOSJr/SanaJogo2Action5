using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rigidbodyX;
    private float velocity = 10f;
    public Transform transformExit;
    public GameObject objShoot;
    private float shootCooldown = 0f;
    private AudioSource audioSourceMove;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyX = GetComponent<Rigidbody2D>();
        audioSourceMove = GetComponent<AudioSource>();
    }

    private void Start()
    {
        respawObjt.respawObjtStatic.AddRespawList(objShoot);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveY != 0f)
        {
            Vector3 posGo = transform.position + Vector3.up * moveY * velocity * Time.fixedDeltaTime;
            rigidbodyX.MovePosition(posGo);
            if (!audioSourceMove.isPlaying)
            {
                audioSourceMove.Play();
            }
        }
        else if(audioSourceMove.isPlaying)
        {
            audioSourceMove.Stop();
        }
    }

    private void Update()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            GameObject objtSht = respawObjt.respawObjtStatic.GetRespawObjt(objShoot);
            objtSht.transform.position = transformExit.position;
            objtSht.SetActive(true);
            shootCooldown = 0.5f;
        }
    }
}
