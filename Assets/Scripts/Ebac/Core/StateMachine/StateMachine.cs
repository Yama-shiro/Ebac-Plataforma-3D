using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Ebac.StateMachine
{
   public class StateMachine<T> where T : System.Enum
   {
      public Dictionary<T, StateBase> DictionaryState;
      private StateBase _currentState;
      public float timeToStartGame = 1f;
      
      public void Update()
      {
         if (_currentState != null)
         {
            _currentState.OnStateStay();
         }
      }
      public void Init()
      {
         DictionaryState = new Dictionary<T, StateBase>();
      }
      public StateBase CurrentState
      {
         get { return _currentState; }
      }

      /*public StateMachine(T state)
      {
         DictionaryState = new Dictionary<T, StateBase>();
         SwitchStates(state);
      }*/
      public void RegisterStates(T typeEnum, StateBase stateBase)
      {
         DictionaryState.Add(typeEnum, stateBase);
      }
      public void SwitchStates(T state, params object[] objects)
      {
         if (_currentState != null)
         {
            _currentState.OnStateExit();
         }

         _currentState = DictionaryState[state];

         if (_currentState != null)
         {
            _currentState.OnStateEnter(objects);
         }
      }
   }
}
