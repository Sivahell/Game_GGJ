using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSlideUI : MonoBehaviour
{
    public Camera uiCamera;
    public LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer.positionCount = 0;

    }

    private void OnEnable()
    {
        MouseInputManager.instance.OnClick += StartLine;
        MouseInputManager.instance.OnHold += UpdateLine;
        MouseInputManager.instance.OnCancel += StopLine;
    }
    private void OnDisable()
    {
        MouseInputManager.instance.OnClick -= StartLine;
        MouseInputManager.instance.OnHold -= UpdateLine;
        MouseInputManager.instance.OnCancel -= StopLine;
    }
    private void StartLine(Vector2 pos)
    {

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, WorldPos(pos));
        lineRenderer.SetPosition(1, WorldPos(pos));
    }

    private void UpdateLine(Vector2 pos)
    {
        lineRenderer.SetPosition(0, WorldPos(BladeControlDetecter.instance.PointSticked()));
        lineRenderer.SetPosition(1, WorldPos(pos));
    }
    private void StopLine(Vector2 pos)
    {
        lineRenderer.positionCount = 0;
     
    }

    public Vector3 WorldPos(Vector2 screenPos)
    {
        var v2 = uiCamera.ScreenToWorldPoint(screenPos);
        v2.z = 10;
        return v2;
    }
}
