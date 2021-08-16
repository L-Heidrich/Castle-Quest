using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{

    public Item currentItem;
    public List<Item> items = new List<Item>();

    public int numberOfMidKeys;
    public int numberOfCastleKeys;
    public int numberOfSmallKeys;
    public int numberOfBossKeys;
    public int numberOfDungeonKeys;




    public void AddItem( Item toAdd)
    {
        if (toAdd.isSmallKey)
        {
            numberOfSmallKeys++;
        }
        if (toAdd.isCastleKey)
        {
            numberOfCastleKeys++;
        }
        if (toAdd.isMidKey)
        {
            numberOfMidKeys++;
        }
        if (toAdd.isBossKey)
        {
            numberOfBossKeys++;
        }
        if (toAdd.isDungeonKey)
        {
            numberOfDungeonKeys++;
        }

    }



}

