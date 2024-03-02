using UnityEngine;

public class WeaponHasLaser : MonoBehaviour
{
    [SerializeField] private float laserDist = 100;
    [SerializeField] private GameObject laserFrom;
    [SerializeField] private LineRenderer lineRenderer;

    void OnUpdate()
    {
        this.ShootLaser();
    }
    void ShootLaser()
    {
        if (Physics2D.Raycast(this.laserFrom.transform.position, this.laserFrom.transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(this.laserFrom.transform.position, this.laserFrom.transform.up);
            this.Draw2DRay(this.laserFrom.transform.position, hit.transform.position);
        }
        else
        {
            this.Draw2DRay(this.laserFrom.transform.position, this.laserFrom.transform.up * this.laserDist);
        }
        
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        this.lineRenderer.SetPosition(0, startPos);
        this.lineRenderer.SetPosition(1, endPos);
    }
}
