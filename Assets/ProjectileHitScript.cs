using ScringloGames.ColorClash.Runtime.Health;
using UnityEngine;

public class ProjectileHitScript : MonoBehaviour
{
    [SerializeField] private new string tag;
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(this.tag))
        {
            var healthHandler = collision.collider.GetComponent<HealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.TakeDamage(this.damage);
            }
        }
        Destroy(this.gameObject);
    }
}
