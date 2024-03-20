using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHasLaser : MonoBehaviour
{
    [SerializeField] private bool alwaysOn = false;
    public bool turnedOn { get; private set; } = false;
    
    [SerializeField] private float laserDist = 100;
    [SerializeField] private GameObject laserFrom;
    /// <summary>
    /// START DISABLED!
    /// </summary>
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask mask;


    private void OnEnable()
    {
        if (alwaysOn)
        {
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
        }

        lineRenderer.enabled = true;
    }

    void Update()
    {
        if (alwaysOn) { ShootLaser();}
    }

    public void TurnLaserOn()
    {
        lineRenderer.positionCount = 2;
        turnedOn = true;
    }

    public void TurnLaserOff()
    {
        lineRenderer.positionCount = 0;
        turnedOn = false;
    }
    public void ShootLaser()
    {
        Vector2 LaserOriginPosition = laserFrom.transform.position;
        Vector2 LaserUp = laserFrom.transform.up;
        if (Physics2D.Raycast(LaserOriginPosition, LaserUp))
        {
            RaycastHit2D hit = Physics2D.Raycast(LaserOriginPosition, LaserUp, laserDist, mask);
            Draw2DRay(LaserOriginPosition, hit.point);
            
        }
        else
        {
            Draw2DRay(LaserOriginPosition, LaserUp * laserDist);
            
        }
        
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
