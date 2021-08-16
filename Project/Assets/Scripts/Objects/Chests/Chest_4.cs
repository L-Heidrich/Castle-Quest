using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest_4 : Interactable
{

    public Item contents;
    public  static bool isOpen;
    public Inventory playerInventory;
    public Signal raiseItem;
    public GameObject dialogBox;
    public static Bool Chestopened;
    public Text dialogText;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       // isOpen = Chestopened.runtimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once  per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogActive)
        {
            if (!isOpen)
            {
                Sound.playSound("chestOpen");

                openChest();
            }
            else
            {
                chestOpen();
            }
        }
    }

    public void openChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemdesc;
        playerInventory.AddItem(contents);

        playerInventory.currentItem = contents;

        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
       // Chestopened.runtimeValue = isOpen;
    }

    public void chestOpen()
    {
       
            dialogBox.SetActive(false);
            raiseItem.Raise();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            Debug.Log("Player in range");
            if (!dialogActive)

                context.Raise();
            dialogActive = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            dialogActive = false;
        }
    }
}

