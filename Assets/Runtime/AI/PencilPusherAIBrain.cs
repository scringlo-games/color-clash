using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

public class PencilPusherAIBrain : MonoBehaviour
{
    /*
     * The Plan:
     * Constantly aims at player
     * Constantly shooting at player
     * Cooldown comes from PaintLauncher script
     * Maybe moves? Probably not?
     */

    private GameObject target;
    [SerializeField] private DirectionalLooker looker;
    [SerializeField] private Weapon weapon;
    void OnEnable()
    {
        target = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = this.target.transform.position;
        var direction = (targetPosition - this.transform.position).normalized;
        looker.Direction = direction;
        weapon.Trigger.Pull();
    }
}
