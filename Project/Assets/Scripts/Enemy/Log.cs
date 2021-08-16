using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;



public class Log : Enemy
{
    // Start is called before the first frame update

    public Rigidbody2D mRigidbody;

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;
    public Animator anim;




    void Start()
    {
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("wakeUp", true);

    }

    // Update is called once per frame
    void Update()
    {    
   
        CheckDistance();
    }

    public virtual void CheckDistance()
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
                ChangeState(EnemyState.walk);
                        anim.SetBool("wakeUp", true);

            }

        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
    
    public void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x)> Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                setAnimFloat(Vector2.right);

            }else if( direction.x < 0)
            {
                setAnimFloat(Vector2.left);

            }

        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                setAnimFloat(Vector2.up);

            }
            else if (direction.y < 0)
            {
                setAnimFloat(Vector2.down);

            }
        }
    }

    private void setAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);

    }
}
