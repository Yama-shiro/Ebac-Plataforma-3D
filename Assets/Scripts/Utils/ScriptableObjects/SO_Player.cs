using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class SO_Player : ScriptableObject
{
    public Animator player;
    public SO_String soPlayerName;
    [Header("Friction")]
        public Vector2 friction = new Vector2(0.1f, 0);
    [Header("Move")]
        public SO_Float soSpeed;
        public SO_Float soSpeedRun;
    [Header("Jump")]
        public SO_Float soJumpForce;
        public SO_Float soJumpScaleX;
        public SO_Float soJumpScaleY;
    [Header("Fall")]
        public SO_Float soFallScaleX;
        public SO_Float soFallScaleY;
    [Header("Animation Duration")]
        public SO_Float soAnimationDurationJump;
        public SO_Float soAnimationDurationFall;
    [Header("Animation Ease")]
        public Ease ease = Ease.OutBack;
    [Header("Animation Player")]
        public string boolRun = "PlayerRun";
        public string boolJump = "PlayerJump";
        public string triggerDeath = "PlayerDeath";
        public float playerSwipeDuration = 0.1f;
}
