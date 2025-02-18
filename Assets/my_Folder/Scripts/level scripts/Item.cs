using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        pistola,
        linterna,
        balas,
        llave,
        nada,

    }

    public ItemType type;
    public int amount;

    
}
