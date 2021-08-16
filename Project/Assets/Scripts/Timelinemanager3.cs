using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timelinemanager3 : MonoBehaviour
{
    private bool fix = false;
    public Animator animator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    public GameObject player;
    public static bool watched4 = false;
     // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing  )
        {
             //animator.runtimeAnimatorController = playerAnim;
            player.SetActive(true);
            director.playOnAwake = false;

        }
        else
        {
            player.SetActive(false);
            StartCoroutine("wait");


        }
    }

        public void OnTriggerEnter2D(Collider2D collision)
         {
        if (!watched4)
        { 
            director.Play();
            watched4 = true;
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(16f);
        SceneManager.LoadScene("Endscreen");


    }
}

