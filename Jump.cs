using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{
    [CreateAssetMenu(fileName = "New state", menuName = "Project2/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;

        public override void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * JumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void UpdateAbility(CharactersState charactersState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = charactersState.GetCharacterControl(animator);

            control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
            control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        }
        public override void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}

