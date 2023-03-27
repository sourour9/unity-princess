using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public enum PanelType
{
    None,
    Menu,
    Credits,
    Information,
    Dialogue,
}
public class MenuController : MonoBehaviour
{
    
    [Header("Panels")]
    [SerializeField] private List<Panel> panels = new List<Panel>();
    private Dictionary<PanelType, Panel> panelDictionary = new Dictionary<PanelType, Panel>();
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
        foreach (Panel panel in panels)
        {
           if(panel) panelDictionary.Add(panel.GetPanelType(), panel);
        }
       
        OpenOnePanel(PanelType.Menu);
        
       
    }

    private void OpenOnePanel(PanelType panelType)
    {
        foreach (Panel panel in panels)
           panel.ChangeState(false);

        if (panelType != PanelType.None)
            panelDictionary[panelType].ChangeState(true);
        
    }

    public void ChangeScene(string sceneName)
    {
        gameManager.ChangeScene(sceneName);
    }

    public void QuitGame()
    {
        gameManager.QuitGame();
    }

    public void OpenPanel(PanelType panelType)
    {
        OpenOnePanel(panelType);
       
    }
}
