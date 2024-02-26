using System;
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
    private AmmunitionBank ammo;

    private bool reloadTimerOn = false;
    [SerializeField] private float reloadTime = 0.5f;
    private float reloadTimer;
    void OnEnable()
    {
        target = GameObject.FindWithTag("Player");
        ammo = weapon.GetComponent<AmmunitionBank>();
        if (ammo == null)
        {
            Debug.Log("Cannot find ammo bank.");
        }
        reloadTimer = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = this.target.transform.position;
        var direction = (targetPosition - this.transform.position).normalized;
        looker.Direction = direction;
        if (ammo.Evaluate())
        {
            weapon.Trigger.Pull();
        }
        else if (!reloadTimerOn)
        {
            reloadTimerOn = true;
        }

        if (reloadTimerOn)
        {
            if (reloadTimer > 0)
            {
                reloadTimer -= Time.deltaTime;
            }
            else
            {
                reloadTimerOn = false;
                reloadTimer = reloadTime;
                ammo.Reload();
            }
        }
    }
}
