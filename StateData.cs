using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2_platformer
{

    public abstract class StateData : ScriptableObject
    {
        public abstract void OnEnter(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void UpdateAbility(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void OnExit(CharactersState characterState, Animator animator, AnimatorStateInfo stateInfo);
    }
}

