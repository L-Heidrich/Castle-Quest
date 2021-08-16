using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour

   
{

    public GameObject pausescreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
     }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            pausescreen.SetActive(false);

            Time.timeScale = 1f;
         }
        else
        {
            pausescreen.SetActive(true);
            Time.timeScale = 0f;
         }

    }

    public void Resume()
    {
        pausescreen.SetActive(false);

        Time.timeScale = 1f;

    }
}
