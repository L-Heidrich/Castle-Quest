using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
 
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D mRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer foundItemSprite;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    { 

        if (currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCO());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
           
            UpdateAnimationAndMove();
        }

    }

    private IEnumerator AttackCO()
    {
        Sound.playSound("swordswing");
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
        if(currentState != PlayerState.interact){
            currentState = PlayerState.walk;
        }

    }

    public void RaiseIten()
    {
        if (playerInventory.currentItem != null)
        {    

            if (currentState != PlayerState.interact)
            {

                animator.SetBool("found_item", true);
                currentState = PlayerState.interact;
                foundItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("found_item", false);
                currentState = PlayerState.idle;
                foundItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }


    }

    void MoveCharacter()
    {
 
        change.Normalize();
        mRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );

    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        

        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCO(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Gameover");


        }


    }

    private IEnumerator KnockCO( float duration)
    {
        if (mRigidbody != null)
        {
            
            yield return new WaitForSeconds(duration);
            mRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            mRigidbody.velocity = Vector2.zero;


        }
    }
}
