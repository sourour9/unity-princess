using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    [SerializeField] private PanelType panelType;
    private bool state;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvas= GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    private void UpdateState()
    {
        canvas.enabled = state;
        
    }

    public void ChangeState()
    {
        state = !state;
        UpdateState();
    }

    public void ChangeState(bool state)
    {
        this.state= state;
        UpdateState();
    }
    #region Getter

    public PanelType GetPanelType()
    {
        return panelType;
    }

    #endregion
}
