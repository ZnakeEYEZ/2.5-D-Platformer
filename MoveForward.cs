using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{
    [CreateAssetMenu(fileName = "New State", menuName = "Project2/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public bool Constant;
        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        private bool Self;

        public override void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharactersState charactersState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = charactersState.GetCharacterControl(animator);
            
            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (Constant)
            {
                ConstantMove(control, animator, stateInfo);
            }
            else
            {
                ControlledMove(control, animator, stateInfo);
            }

        }

        public override void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private void ConstantMove(CharacterControl control, Animation animator, AnimationState stateInfo)
        {
            if (!CheckFront(control))
            {
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }
        }

        private void ControlledMove(CharacterControl control, Animation animator, AnimationState stateInfo)
        {
            //Code to control the Walk animations
            if (control.MoveRight && control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }
            }

            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                    control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
        }

        bool CheckFront(CharacterControl control)
        {

            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);

                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    foreach(Collider c in control.RagdollParts)
                    {
                        if (c.gameObject == hit.collider.gameObject)
                        {
                            Self = true;
                            break;
                        }
                    }
                    if (!Self)
                    {
                        return true;
                    }
                    
                }
            }

            return false;
        }
    }
}

