using UnityEngine;

/*
 * Fires given object, with a public velocity, distance from origin and cooldown, up.
 */

namespace ScringloGames.ColorClash.Runtime.Weapons
{
    public class ProjectileLauncher : MonoBehaviour
    {
        // Velocity
        [SerializeField] private float launchVelocity = 1.0f;
        [SerializeField] private float pitchVariation = 0.5f;
        [SerializeField] private GameObject objectToLaunch;
        [SerializeField] private GameObject fireFrom;

        public GameObject ObjectToLaunch
        {
            get => this.objectToLaunch;
            set => this.objectToLaunch = value;
        }

        public void Launch()
        {
            if (this.TryGetComponent(out AudioSource audioSource))
            {
                audioSource.pitch = (this.pitchVariation * Random.value) + 1.0f;
                audioSource.Play();
            }
            var newProjectile = 
                Instantiate(this.objectToLaunch, this.fireFrom.transform.position, this.transform.rotation);
            Vector2 launchSpeed = this.transform.up * this.launchVelocity;
            newProjectile.GetComponent<Rigidbody2D>().velocity = launchSpeed;
        }

    }
}
