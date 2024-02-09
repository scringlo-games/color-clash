using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class MoveToGameObject : MonoBehaviour
    {
        [SerializeField] private string MoveToTag = "Player";
        [SerializeField] public float Velocity = 1;
        private GameObject MoveToObj;
        private Rigidbody2D MyRigidBody;

        // Start is called before the first frame update
        private void Start()
        {
            this.MoveToObj = GameObject.FindGameObjectWithTag(this.MoveToTag);
            this.MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        { 
            Vector2 moveDir = this.MoveToObj.transform.position - this.gameObject.transform.position;
            moveDir = moveDir.normalized;
            Vector2 MoveVelocity = moveDir * this.Velocity;
            this.MyRigidBody.velocity = MoveVelocity;
        }

    
    }
}

