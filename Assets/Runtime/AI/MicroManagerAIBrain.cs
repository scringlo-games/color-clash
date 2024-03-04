using System.Collections;
using System.Collections.Generic;
using ScringloGames.ColorClash.Runtime.Aiming;
using ScringloGames.ColorClash.Runtime.Movement;
using ScringloGames.ColorClash.Runtime.Weapons;
using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class MicroManagerAIBrain : MonoBehaviour
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
        private AmmunitionBank ammo;
        [SerializeField]
        private DestinationMover mover;

        [SerializeField] private GameObject[] spawners;
        [SerializeField] private float firstSpawnDelay = .1f;
        private float firstSpawnTimer;
        private bool spawnersActive = false;
        
        void OnEnable()
        {
            this.target = GameObject.FindWithTag("Player");
            firstSpawnTimer = firstSpawnDelay;
        }

        // Update is called once per frame
        void Update()
        {
            if (!spawnersActive)
            {
                if (firstSpawnTimer <= 0)
                {
                    spawnersActive = true;
                    foreach (GameObject o in spawners)
                    {
                        o.SetActive(true);
                    }
                }
                firstSpawnTimer -= Time.deltaTime;
            }
            var targetPosition = this.target.transform.position;
            var direction = (targetPosition - this.transform.position).normalized;
            this.looker.Direction = direction;
            this.mover.MoveTo(this.target.transform.position);
        }
    }
}
