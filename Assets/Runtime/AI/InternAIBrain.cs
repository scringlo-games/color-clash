using ScringloGames.ColorClash.Runtime.Attacks;
using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.AI
{
    public class InternAIBrain : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private DestinationMover mover;
        [SerializeField]
        private AttackBehaviour attackBehaviour;
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
                this.attackBehaviour.Attack();
            }
            else
            {
                this.mover.MoveTo(destination);
            }
        }
    }
}
