using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyInventoryUI : MonoBehaviour
{
   private TextMeshProUGUI diamondText;

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfKeys.ToString();
    }
}
