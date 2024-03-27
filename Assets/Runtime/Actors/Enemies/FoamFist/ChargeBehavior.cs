using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Shared.Attributes;
using TravisRFrench.Attributes.Runtime;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Actors.Enemies.FoamFist
{
    public class ChargeBehavior : MonoBehaviour
    {
          [SerializeField]
          private AttributeBank attributeBank;
          [SerializeField]
          private DestinationMover mover;
          [SerializeField]
          private float chargeSpeed = 5f;
          [SerializeField]
          private float duration = 4f;
          private float durationT;
          private Vector2 target;
          private AttributeModifier modifier;
          private Vector2 previousPos;
          void OnEnable()
          {
               this.modifier = new AttributeModifier()
               {
                    Value = chargeSpeed,
                    Type = ModifierType.FlatMultiplicative,
               };
               this.attributeBank.MovementSpeedMultiplier.AddModifier(modifier);
               this.durationT = this.duration;
               this.target = GameObject.FindWithTag("Player").transform.position;
               this.mover.MoveTo(target);
               this.mover.Arrived += Arrived;
               previousPos = this.transform.position;


          }
          void Update()
          {
               durationT -= Time.deltaTime;
               if(durationT <= 0 )
               {
                    Arrived();
               }
               
          }
          void OnDisable()
          {
               Debug.Log("DISABLED");
               mover.Halt();
               mover.Arrived -= Arrived;
               this.attributeBank.MovementSpeedMultiplier.RemoveModifier(modifier);
          }
          void Arrived()
          {
               this.enabled = false;
          }


    }
}
