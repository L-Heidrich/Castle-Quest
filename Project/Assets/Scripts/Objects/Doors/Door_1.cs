using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door_1 : Interactable
{
    public enum DoorType
    {
        DungeonKey,
        Midkey,
        Bosskey,
        Castlekey,
        Smallkey,
        enemy,
        keyless,
    }

    [Header("Door variables")]
    public DoorType thisDoorType;
    public static bool open = false;

    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;



    void Start()
    {

        if (open)
        {
            Open();
        }
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !open)
        {



            if (dialogActive && thisDoorType == DoorType.Castlekey)
            {
                if (playerInventory.numberOfCastleKeys > 0)
                {
                    playerInventory.numberOfCastleKeys--;
                    Open();
                }

            }

            if (dialogActive && thisDoorType == DoorType.Smallkey)
            {
                if (playerInventory.numberOfSmallKeys > 0)
                {
                    playerInventory.numberOfSmallKeys--;
                    Open();
                }

            }

            if (dialogActive && thisDoorType == DoorType.DungeonKey)
            {
                if (playerInventory.numberOfDungeonKeys > 0)
                {
                    playerInventory.numberOfDungeonKeys--;
                    Open();
                }

            }

            if (dialogActive && thisDoorType == DoorType.Bosskey)
            {
                if (playerInventory.numberOfBossKeys > 0)
                {
                    playerInventory.numberOfBossKeys--;
                    Open();
                }

            }


            if (dialogActive && thisDoorType == DoorType.Midkey)
            {
                if (playerInventory.numberOfMidKeys > 0)
                {
                    playerInventory.numberOfMidKeys--;
                    Open();
                }

            }
            if (dialogActive && thisDoorType == DoorType.keyless)
            {
                Open();

            }

        }
        if (open == true)
        {
            Open();
        }
    }

    public void Open()
    {
         

        open = true;
        doorSprite.enabled = false;
        physicsCollider.enabled = false;

    }

    public void Close()
    {

    }
}
