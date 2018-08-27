﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
namespace RPG.Characters
{
    public class AoEBehaviour : MonoBehaviour, ISpecialAbility
    {
        AoEConfig config;

        public void SetConfig(AoEConfig configToSet) {
            config = configToSet;
        }

        // Use this for initialization
        void Start()
        {
            print("AoE behaviour attached to " + gameObject.name);
        }

        public void Use(AbilityUseParams abilityUseParams)
        {
            //sphere cast to radius
            RaycastHit[] hits = Physics.SphereCastAll(
                transform.position,
                config.GetRadius(),
                Vector3.up,
                config.GetRadius()
            );
            foreach (RaycastHit hit in hits) {
                var damageable = hit.collider.gameObject.GetComponent<IDamageable>();
                
                if (damageable != null)
                {
                    if (damageable.Equals(abilityUseParams.target) == false)
                    {
                        abilityUseParams.baseDamage = abilityUseParams.target.CalculateHitProbability(abilityUseParams.baseDamage, damageable);
                        damageable.TakeDamage(abilityUseParams.baseDamage + config.GetDamageToEachTarget());
                    }
                }
            }
        }
    }
}
