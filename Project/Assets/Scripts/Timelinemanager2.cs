﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Timelinemanager2 : MonoBehaviour
{
    private bool fix = false;
    public Animator animator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;
    public GameObject player;
    public static bool watched3 = false;
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

        }
    }

        public void OnTriggerEnter2D(Collider2D collision)
         {
        if (!watched3)
        { 
            director.Play();
            player.SetActive(false);
            watched3 = true;
        }
        
          }
}

