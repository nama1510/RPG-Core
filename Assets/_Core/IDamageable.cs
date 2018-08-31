﻿
namespace RPG.Core
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        float CalculateHitProbability(float damage, IDamageable target);
    }
}
