using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("New scene Variables")]
    public string targetScene;
    public Vector2 playerPosition;
    public VectorValue temp;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    public Vector2 cameranewMin;
    public Vector2 cameranewMax;



    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger){

            temp.initialValue = playerPosition;
            resetCameraBounds();
            SceneManager.LoadScene(targetScene);
            Sound.playSound("doorOpen");

        }
    }

    public void resetCameraBounds()
    {
        cameraMax.initialValue = cameranewMax;
        cameraMin.initialValue = cameranewMin;
    }
}
