using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
   public GunBase gunBase;
   public Transform gunPosition;
   private GunBase _currentGunBase;
   public GunShootLimit prefabLimit;
   public GunShootAngle prefabAngle;
   public FlashColor flashColor;
   protected override void Init()
   {
      base.Init();
      CreateGun();
      inputs.Gameplay.Shoot.performed += context => StartShoot();
      inputs.Gameplay.Shoot.canceled += context => CancelShoot();
      
      inputs.Gameplay.ChangeToGunShootLimit.performed += context => ChangeGun(prefabLimit);
      inputs.Gameplay.ChangeToGunShootAngle.performed += context => ChangeGun(prefabAngle);

   }
   private void CreateGun()
   {
      _currentGunBase = Instantiate(gunBase,gunPosition);
      //_currentGunBase.transform.localPosition = _currentGunBase.transform.localEulerAngles = Vector3.zero;
      _currentGunBase.transform.localPosition = Vector3.zero;
      _currentGunBase.transform.localEulerAngles = Vector3.zero;
   }
   private void StartShoot()
   {
      _currentGunBase.StartShoot();
      flashColor?.Flash();
      Debug.Log("StartShoot");
   }
   private void CancelShoot()
   {
      _currentGunBase.StopShoot();
      Debug.Log("CancelShoot");
   }

   private void ChangeGun(GunBase newGunBase)
   {
      Debug.Log("NewGun");
      gunBase = newGunBase;
      Destroy(gunPosition.GetChild(0).gameObject);
      _currentGunBase = null;
      _currentGunBase = Instantiate(gunBase,gunPosition);
   }
}
