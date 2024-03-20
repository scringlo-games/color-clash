using ScringloGames.ColorClash.Runtime.Aiming;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class LookTowardPlayerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private DirectionalLooker looker;
        private GameObject player;
        
        private void Awake()
        {
            this.player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            var from = this.transform.position;
            var to = this.player.transform.position;
            this.looker.Direction = (to - from).normalized;
        }
    }
}
