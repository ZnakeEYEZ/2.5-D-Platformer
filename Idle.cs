using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{
    [CreateAssetMenu(fileName = "New state", menuName = "Project2/AbilityData/Idle")]
    public class Idle : StateData
    {

        public override void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }         

        public override void UpdateAbility(CharactersState charactersState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = charactersState.GetCharacterControl(animator);
            
            
            
            if (control.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }
            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
            //Code to control the Idle animations
            if (control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }
        public override void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

    }
}

