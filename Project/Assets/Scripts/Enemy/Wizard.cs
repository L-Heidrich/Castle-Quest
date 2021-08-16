using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wizard : Log
{

    public GameObject projectile;
    public float delay;
    private float delaySeconds;
    public bool canFire;

     


     


    public override void CheckDistance()
    {


        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)

        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)

            {

                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                            target.position,
                                                                moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                mRigidbody.MovePosition(temp);


                if (canFire)
                {
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().shoot(tempVector);
                    canFire = false;


                    ChangeState(EnemyState.walk);
                    anim.SetBool("wakeUp", true);

                    StartCoroutine("wait");
                }

            }


        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }

    }

    IEnumerator wait()
    {

        Sound.playSound("magic1");
        yield return new WaitForSeconds(2);
        Debug.Log("2secs over");
        canFire = true;

    }
  
}

    
