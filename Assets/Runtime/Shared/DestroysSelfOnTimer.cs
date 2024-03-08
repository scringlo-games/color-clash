using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;

public class DestroysSelfOnTimer : MonoBehaviour
{
    [SerializeField] private float Lifetime;
    [SerializeField] private Destructible destructible;

    private float lifeLeft;
    // Start is called before the first frame update
    void OnEnable()
    {
        this.lifeLeft = this.Lifetime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.lifeLeft <= 0)
        {
            this.destructible.Destroy();
        }
        else
        {
            this.lifeLeft -= Time.deltaTime;
        }
    }
}
