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
        lifeLeft = Lifetime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeLeft <= 0)
        {
            destructible.Destroy();
        }
        else
        {
            lifeLeft -= Time.deltaTime;
        }
    }
}
