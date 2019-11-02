using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{
    [CreateAssetMenu(fileName = "New state", menuName = "Project2/AbilityData/Landing")]
    public class Landing : StateData
    {

        public override void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            animator.SetBool(TransitionParameter.Move.ToString(), false);
        }

        public override void UpdateAbility(CharactersState charactersState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
        public override void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}

