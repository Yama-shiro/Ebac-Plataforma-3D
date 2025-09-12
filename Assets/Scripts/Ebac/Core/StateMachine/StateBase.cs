using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(params object[] objects)
        {
            //Debug.Log("OnStateEnter");
        }

        public virtual void OnStateStay()
        {
            //Debug.Log("OnStateStay");
        }

        public virtual void OnStateExit()
        {
            //Debug.Log("OnStateExit");
        }
    }
}