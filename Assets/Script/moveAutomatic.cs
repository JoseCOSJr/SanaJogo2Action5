using UnityEngine;

public class moveAutomatic : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private Rigidbody2D rigidbodyX;
    [SerializeField]
    private bool enemyProgetil = true;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyX = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 speedGo = speed;

        if (enemyProgetil)
            speedGo *= enemieMove.speedShoot;
            
        

        if (rigidbodyX.velocity != speedGo)
        {
            rigidbodyX.velocity = speedGo;
        }
    }
}
