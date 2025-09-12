using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public enum TypeAnimation
    {
        None,
        Idle, 
        Run, 
        Attack,
        Death
    }
    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSetup> animationSetups;
        public void AnimationPlayByTrigger(TypeAnimation typeAnimation)
        {
            var setup = animationSetups.Find(i => i.typeAnimation == typeAnimation);
            if (setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
    }
    [System.Serializable]
    public class AnimationSetup
    {
        public TypeAnimation typeAnimation;
        public string trigger;
    }
}
