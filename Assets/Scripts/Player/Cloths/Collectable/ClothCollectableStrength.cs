using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothCollectableStrength : ClothCollectableBase
    {
        public override void Collect()
        {
            base.Collect();
            ClothStrengthSO clothStrengthSo = (ClothStrengthSO)clothBaseSo;
            ApplyPowerUp(clothStrengthSo.damageMultiply,clothStrengthSo.duration);
        }
        public static void ApplyPowerUp(float damageMultiply,float duration)
        {
            Player.Instance.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
    }
}
