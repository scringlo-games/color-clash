using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHasLaser : MonoBehaviour
{
    [SerializeField] private float laserDist = 100;
    [SerializeField] private GameObject laserFrom;
    [SerializeField] private LineRenderer lineRenderer;

    void OnUpdate()
    {
        ShootLaser();
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(laserFrom.transform.position, laserFrom.transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserFrom.transform.position, laserFrom.transform.up);
            Draw2DRay(laserFrom.transform.position, hit.transform.position);
        }
        else
        {
            Draw2DRay(laserFrom.transform.position, laserFrom.transform.up * laserDist);
        }
        
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
