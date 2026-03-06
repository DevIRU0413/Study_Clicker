using UnityEngine;

namespace GoldMetal_Jelly
{
    public class JellyWalkState : JellyBaseState
    {
        private Transform _tr;

        private Vector3 _dir = Vector3.zero;
        private float _durationTime = 2.5f;
        private float _currentMoveSpeed = 0f;

        public JellyWalkState(JellyStateMachine machine, JellyStateType stateType) : base(machine, stateType) 
        { 
            _tr = machine.transform;
        }

        public override void Enter()
        {
            base.Enter();

            _currentMoveSpeed = machine.Ability.MoveSpeed;

            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            _dir = new Vector3(x, y, y);

            machine.SpriteRenderer.flipX = (_dir.x <= 0);
            machine.Animator.SetBool("isWalk", true);
        }

        public override void Exit()
        {
            base.Exit();
            machine.Animator.SetBool("isWalk", false);
        }

        public override void Tick()
        {
            base.Tick();
            _tr.Translate(_currentMoveSpeed * Time.deltaTime * _dir);

            if (!CheckInBorder())
            {
                ReDirection();
            }
        }

        public override JellyStateType TransEvent()
        {
            JellyStateType transType = JellyStateType.None;

            if (_durationTime <= enterTime)
                transType = JellyStateType.Idle;

            return transType;
        }

        private bool CheckInBorder()
        {
            GameObject[] list = machine.Manager.BorderList;
            if (list == null) return false;

            Vector2 bottomLeft = list[0].transform.position;
            Vector2 topRight = list[1].transform.position;
            Vector2 curront = _tr.position;

            Bounds bounds = new Bounds();
            bounds.SetMinMax(bottomLeft, topRight);

            bool isInside = bounds.Contains(curront);
            return isInside;
        }

        private void ReDirection()
        {
            GameObject[] list = machine.Manager.RespawnPointList;
            Vector3 respawnPoint = Vector3.zero;
            if(list != null)
            {
                int num = Random.Range(0, list.Length);
                respawnPoint = list[num].transform.position;
            }
            _dir = (respawnPoint - _tr.position).normalized;
            machine.SpriteRenderer.flipX = (_dir.x <= 0);
        }
    }
}