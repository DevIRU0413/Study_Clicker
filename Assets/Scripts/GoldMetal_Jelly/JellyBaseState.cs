using UnityEngine;

namespace GoldMetal_Jelly
{
    public class JellyBaseState : IJellyState
    {
        protected JellyStateMachine machine;
        protected JellyStateType stateType;
        protected double enterTime;

        public JellyBaseState(JellyStateMachine machine, JellyStateType stateType)
        {
            this.machine = machine;
            this.stateType = stateType;
            enterTime = 0.0d;
        }

        public virtual void Enter()
        {
            enterTime = 0.0d;
        }

        public virtual void Exit() { }

        public virtual void Tick()
        {
            enterTime += Time.deltaTime;
        }

        public virtual JellyStateType TransEvent() 
        { 
            return JellyStateType.None; 
        }
    }
}