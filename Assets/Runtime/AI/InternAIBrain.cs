using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class InternAIBrain : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private DestinationMover mover;
        [FormerlySerializedAs("attackBehaviour")]
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private float attackDistance = 1f;

        private void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            var destination = this.target.transform.position;
            var distance = Vector2.Distance(this.transform.position, destination);
            
            if (distance <= this.attackDistance)
            {
                this.weapon.Trigger.Pull();
            }
            else
            {
                this.weapon.Trigger.Release();
                this.mover.MoveTo(destination);
            }
        }
    }
}
