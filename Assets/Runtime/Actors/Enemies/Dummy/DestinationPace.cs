using ScringloGames.ColorClash.Runtime.Movement;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Actors.Enemies.Dummy
{
    public class DestinationPace : MonoBehaviour
    {
        [SerializeField]  
        private DestinationMover mover;
        [SerializeField]
        private GameObject point1;
        [SerializeField]
        private GameObject point2;
        private GameObject target;

         void OnEnable()
        {
            mover.Arrived += Arrived;
            if(point1 != null && point2 != null)
            {
                this.mover.MoveTo(point1.transform.position);
                this.target = point1;
            }
        }
        void OnDisable()
        {
            this.mover.Arrived -= Arrived;
        }
        void Arrived()
        {
            Debug.Log("arrived");
            if(point1 != null && point2 != null)
            {
                if(target == point1)
                {
                    Debug.Log("flungle :)");
                    target = point2;
                    mover.MoveTo(point2.transform.position);
                    Debug.Log(point2.transform.position);
                }
                else if (target == point2)
                {
                    Debug.Log("flungus :(");
                    target = point1;
                    mover.MoveTo(point1.transform.position);
                }
            }
        }
    }
}
