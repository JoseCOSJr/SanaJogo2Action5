using UnityEngine;

public class moveAutomatic : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity != speed)
        {
            rigidbody.velocity = speed;
        }
    }
}
