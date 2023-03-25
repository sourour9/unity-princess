using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{
   public int NumberOfCoins { get; private set; }
   public int NumberOfKeys { get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;
    public UnityEvent<PlayerInventory> OnKeysCollected;

    public void DiamondCollected()
    {
        NumberOfCoins++;
        OnDiamondCollected.Invoke(this);
    }
    public void KeysCollected()
    {
        NumberOfKeys++;
        OnKeysCollected.Invoke(this);
    }
}
