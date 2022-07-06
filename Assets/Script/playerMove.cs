using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float velocity = 10f;
    public Transform transformExit;
    public GameObject objShoot;
    private float shootCooldown = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
            rigidbody.MovePosition(posGo);
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
            shootCooldown = 0.3f;
        }
    }
}
