using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

public class OnVelocityStopDestroysSelf : MonoBehaviour
{
    [SerializeField] private Destructible destructible;
    [SerializeField] private float minimumSpeed;
    private Rigidbody2D me;
    
    // Start is called before the first frame update
    void Start()
    {
        this.me = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= this.minimumSpeed)
        {
            this.destructible.Destroy();
        }
    }
}
