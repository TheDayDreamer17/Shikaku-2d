using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
public class UIBase : MonoBehaviour
{
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private bool _isActive;
    public bool IsActive => _isActive;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        // Show();
    }

    public virtual void Enable()
    {
        _isActive = _canvas.enabled = _canvasGroup.blocksRaycasts = true;
    }

    public virtual void Disable()
    {
        _isActive = _canvas.enabled = _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        if (_isActive) return;
        Enable();
    }
    public void Hide()
    {

        Disable();
    }
    private void OnDestroy()
    {
        _canvas = null;
    }
}
