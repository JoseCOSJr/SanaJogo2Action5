using UnityEngine;

public class progetilHit : MonoBehaviour
{
    public string tagDisable = "Ballons";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagDisable != "")
        {
            if (collision.gameObject.CompareTag(tagDisable))
            {
                collision.gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagDisable != "")
        {
            if (collision.CompareTag(tagDisable))
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
