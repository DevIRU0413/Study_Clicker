using UnityEngine;

namespace GoldMetal_Jelly
{
    public class JellyIdleState : JellyBaseState
    {
        private float _durationTime = 0.0f;
        private Vector2 _transDelayRandomTime = new Vector2(3.0f, 5.0f);

        public JellyIdleState(JellyStateMachine machine, JellyStateType stateType) : base(machine, stateType) { }

        public override void Enter()
        {
            base.Enter();
            _durationTime = Random.Range(_transDelayRandomTime.x, _transDelayRandomTime.y);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Tick()
        {
            base.Tick();
        }

        public override JellyStateType TransEvent()
        {
            JellyStateType transType = JellyStateType.None;

            if (_durationTime <= enterTime)
                transType = JellyStateType.Walk;

            return transType;
        }
    }
}