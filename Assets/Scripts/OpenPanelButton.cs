using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private PanelType panelType;

    private MenuController menuController;
    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    public void OnClick()
    {
        menuController.OpenPanel(panelType);
    }
}
