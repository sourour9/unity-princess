using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyInventoryUI : MonoBehaviour
{
   private TextMeshProUGUI keyText;

    // Start is called before the first frame update
    void Start()
    {
        keyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        keyText.text = playerInventory.NumberOfKeys.ToString();
    }
}
