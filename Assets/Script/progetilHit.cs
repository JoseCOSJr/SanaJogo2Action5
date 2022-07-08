using UnityEngine;

public class progetilHit : MonoBehaviour
{
    public string tagDisable = "Ballons";
    public int pointsValue = 3;
    public AudioClip audioClipHit, audioClipAppear;


    private void OnEnable()
    {
        if (audioClipAppear)
        {
            soundsEfxRepository.instancie.GetAudioSource().PlayOneShot(audioClipAppear);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagDisable != "")
        {
            if (collision.gameObject.CompareTag(tagDisable))
            {
                collision.gameObject.SetActive(false);
                if (audioClipHit)
                {
                    soundsEfxRepository.instancie.GetAudioSource().PlayOneShot(audioClipHit);
                }
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
                if (audioClipHit)
                {
                    soundsEfxRepository.instancie.GetAudioSource().PlayOneShot(audioClipHit);
                }
            }
        }
    }
}
