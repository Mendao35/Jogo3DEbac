using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    public enum AnimationType
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }

    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSetup> animationSetupList;

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            var setup = animationSetupList.Find(i => i.animationType == animationType);
            if(setup != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
    }

    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationType animationType;
        public string trigger;
    }
}

