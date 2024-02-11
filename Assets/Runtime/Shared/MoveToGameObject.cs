using UnityEngine;
using UnityEngine.Serialization;

namespace ScringloGames.ColorClash.Runtime.Shared
{
    public class MoveToGameObject : MonoBehaviour
    {
        [FormerlySerializedAs("MoveToTag")]
        [SerializeField] private string moveToTag = "Player";
        [FormerlySerializedAs("Velocity")]
        [SerializeField] public float velocity = 1;
        private GameObject moveToObj;
        private Rigidbody2D myRigidBody;

        // Start is called before the first frame update
        private void Start()
        {
            this.moveToObj = GameObject.FindGameObjectWithTag(this.moveToTag);
            this.myRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        { 
            Vector2 moveDir = this.moveToObj.transform.position - this.gameObject.transform.position;
            moveDir = moveDir.normalized;
            var moveVelocity = moveDir * this.velocity;
            this.myRigidBody.velocity = moveVelocity;
        }

    
    }
}

