using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip swordswing,stepPlayer,door,pot,chest,magic, fire, music;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        swordswing = Resources.Load<AudioClip>("swing");
        pot = Resources.Load<AudioClip>("potSound");
        door = Resources.Load<AudioClip>("doorOpen");
        magic = Resources.Load<AudioClip>("magic1");
        chest = Resources.Load<AudioClip>("chestOpen");





        audiosrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "swordswing":
                 audiosrc.PlayOneShot(swordswing);
                break;

            case "doorOpen":
                audiosrc.PlayOneShot(door);
                break;

            case "chestOpen":
                audiosrc.PlayOneShot(chest);
                break;

            case "magic1":
                audiosrc.PlayOneShot(magic);
                break;

            case "potSound":
                audiosrc.PlayOneShot(pot);
                break;


        }
    }
    


}
