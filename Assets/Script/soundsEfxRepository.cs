using System.Collections.Generic;
using UnityEngine;

public class soundsEfxRepository : MonoBehaviour
{
    public static soundsEfxRepository instancie;
    public AudioSource audioSourceOriginal;
    private List<AudioSource> audioSourcesList = new List<AudioSource>();

    // Start is called before the first frame update
    void Awake()
    {
        instancie = this;

        for(int i = 0; i < 32; i++)
        {
            AudioSource audioSourceX = Instantiate(audioSourceOriginal);
            audioSourceX.name = audioSourceOriginal.name;
            audioSourceX.transform.SetParent(transform);
            audioSourcesList.Add(audioSourceX);
        }
    }

    public AudioSource GetAudioSource()
    {
        AudioSource adX = audioSourcesList.Find(x => !x.isPlaying);

        if (!adX)
        {
            for (int i = 0; i < 10; i++)
            {
                adX = Instantiate(audioSourceOriginal);
                adX.name = audioSourceOriginal.name;
                adX.transform.SetParent(transform);
                audioSourcesList.Add(adX);
            }
        }

        adX.priority = Random.Range(100, 200);
        adX.loop = false;
        adX.volume = 1f;

        return adX;
    }
}
