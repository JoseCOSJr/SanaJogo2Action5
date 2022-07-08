using UnityEngine;

public class moveAutomatic : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private Rigidbody2D rigidbodyX;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyX = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbodyX.velocity != speed)
        {
            rigidbodyX.velocity = speed;
        }
    }
}
