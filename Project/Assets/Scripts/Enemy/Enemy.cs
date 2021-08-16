using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using UnityEngine.SceneManagement;


public enum EnemyState{

     idle,
     walk,
     attack,
     stagger
}
public class Enemy : MonoBehaviour
{
    public GameObject chest;

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string eName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathAnimation;


    public bool isWizard;
    public PlayableDirector director;






    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    void Start()
    {
        
            
     }

    public void Knock(Rigidbody2D myRigidbody, float duration, float damage)
    {
        StartCoroutine(KnockCO(myRigidbody, duration));
        takeDamage(damage);
        
    }

    private IEnumerator KnockCO(Rigidbody2D myRigidbody, float duration)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(duration);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;


        }
    }

    private void takeDamage(float damage)
    {
        
        health -= damage;
        if(health<= 0)
        {
            this.gameObject.SetActive(false);
            DeathAnimation();

            if (health <= 0 && chest != null)
            {
                chest.SetActive(true);

            }

            if (isWizard)
            {
                director.Play();

            }

        }

    }

     
    private void DeathAnimation()
    {
        if(deathAnimation != null)
        {
            GameObject deathEffect = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(deathEffect, 1f);
        }
    }
}
