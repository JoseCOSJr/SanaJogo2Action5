using UnityEngine;

public class moveAutomatic : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private Rigidbody2D rigidbodyX;
    [SerializeField]
    private bool enemyProgetil = true;
    private bool stop = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyX = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        stop = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 speedGo = speed;

        if (stop)
            speedGo = Vector2.zero;

        if (enemyProgetil)
            speedGo *= enemieMove.speedShoot;
            
        

        if (rigidbodyX.velocity != speedGo)
        {
            rigidbodyX.velocity = speedGo;
        }
    }

    public void StopMovement()
    {
        stop = true;
    }

    public void StartMovement()
    {
        stop = false;
    }
}
