using System;
using System.Collections;
using System.Collections.Generic;
//using Cloth;
using UnityEngine;
using Core.Singleton;

namespace Cloth
{
    public enum TypeCloth
    {
        ClothBasic,
        ClothSpeed,
        ClothStrength,
        ClothColor
    }

    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetups;
        public Texture2D texture2DLast;
        public TypeCloth typeClothLast;
        public ClothBaseSO clothBaseSo;
        private int _clothReferenceId;

        public ClothSetup GetSetupByType(TypeCloth typeCloth)
        {
            return clothSetups.Find(i => i.typeCloth == typeCloth);
        }

        public void SaveCloth(Texture2D texture2D)
        {
            texture2DLast = texture2D;
        }
        public void SaveCloth(ClothBaseSO clothSo,int callerInstanceId)
        {
            clothBaseSo = clothSo;
            _clothReferenceId = callerInstanceId;
        }

        public void RemoveCloth(int callerInstanceId)
        {
            if (_clothReferenceId == callerInstanceId)
            {
                _clothReferenceId = 0;
                clothBaseSo = null;
            }
        }

        public ClothBaseData ConvertClothData(ClothBaseSO clothBaseSo)
        {
            ClothBaseData converted = null;
            bool error = false;
            if (clothBaseSo is ClothStrengthSO)
            {
                converted = new ClothStrengthData();
                ((ClothStrengthData)converted).damageMultiply = ((ClothStrengthSO)clothBaseSo).damageMultiply;
            }
            else if (clothBaseSo is ClothSpeedSO)
            {
                converted = new ClothBaseData();
                ((ClothSpeedData)converted).targetSpeed = ((ClothSpeedSO)clothBaseSo).targetSpeed;
            }
            else
            {
                error = true;
            }

            if (!error)
            {
                converted.duration = clothBaseSo.duration;
                converted.typeCloth = clothBaseSo.typeCloth;
            }

            return converted;
        }
    }

    [Serializable]
    public class ClothSetup
    {
        public TypeCloth typeCloth;
        public Texture2D texture2D;
    }

    [Serializable]
    public class ClothBaseData
    {
        public TypeCloth typeCloth;
        public float duration;
    }

    [Serializable]
    public class ClothStrengthData : ClothBaseData
    {
        public float damageMultiply;
    }
    
    [Serializable]
    public class ClothSpeedData : ClothBaseData
    {
        public float targetSpeed;
    }
}
