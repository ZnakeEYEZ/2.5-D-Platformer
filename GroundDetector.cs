﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{
    [CreateAssetMenu(fileName = "New state", menuName = "Project2/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f, 1f)]
        public float CheckTime;
        public float Distance;

        public override void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void UpdateAbility(CharactersState charactersState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = charactersState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= CheckTime)
            {
                if (IsGrounded(control))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);

                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }
        public override void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        bool IsGrounded(CharacterControl control)
        {
            if (control.RIGID_BODY.velocity.y > -0.001f && control.RIGID_BODY.velocity.y <= 0f)
            {
                return true;
            }

            if (control.RIGID_BODY.velocity.y < 0f)
            {
                foreach (GameObject o in control.BottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);

                    RaycastHit hit;
                    if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

