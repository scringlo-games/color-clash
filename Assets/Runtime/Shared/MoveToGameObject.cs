using ScringloGames.ColorClash.Runtime.Shared.Attributes;
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
        private AttributeBank attributeBank;

        private void Awake()
        {
            this.attributeBank = this.GetComponent<AttributeBank>();
        }

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
            
            // We're not guaranteed to have an AttributeBank just because we can move, so let's check and assign
            // the value of our multiplier if successful.
            var globalMovementSpeedMultiplier = 1f;
            
            if (this.attributeBank != null)
            {
                globalMovementSpeedMultiplier = this.attributeBank.MovementSpeedMultiplier.ModifiedValue;
            }
            
            var moveVelocity = moveDir * (this.velocity * globalMovementSpeedMultiplier);
            this.myRigidBody.velocity = moveVelocity;
        }
    }
}
