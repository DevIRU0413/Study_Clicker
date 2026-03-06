using System;
using UnityEngine;
namespace GoldMetal_Jelly
{
    public enum JellyStateType
    {
        None = 0,
        Idle,
        Walk,
    }

    public class JellyStateMachine : MonoBehaviour
    {
        private IJellyState _idleState;
        private IJellyState _walkState;
        
        [SerializeField]private IJellyState _currentState = null;

        public JellyStateType OldStateType { get; private set; } = JellyStateType.None;
        public JellyStateType CurrentStateType { get; private set; } = JellyStateType.None;

        public Action StateEnter;
        public Action StateExit;
        public Action StateTick;
        public Func<JellyStateType> StateTransEvent;

        // Unity CS
        public Animator Animator { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }

        // Custom CS
        public GameManager Manager { get; private set; }

        public JellyAbility Ability { get; private set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();

            Ability = GetComponent<JellyAbility>();

            _idleState = new JellyIdleState(this, JellyStateType.Idle);
            _walkState = new JellyWalkState(this, JellyStateType.Walk);
        }

        void Start()
        {
            Manager = GameManager.Instance;

            SwitchState(JellyStateType.Idle);
        }

        void Update()
        {
            if (CurrentStateType == JellyStateType.None) return;
            
            StateTick.Invoke();
            SwitchState(StateTransEvent.Invoke());
        }

        public void SwitchState(JellyStateType stateType)
        {
            if (stateType == JellyStateType.None) return;
            if (CurrentStateType == stateType) return;

            if (CurrentStateType != JellyStateType.None)
            {
                // 탈출
                StateExit.Invoke();

                // 상태 액션 해제
                StateEnter -= _currentState.Enter;
                StateExit -= _currentState.Exit;
                StateTick -= _currentState.Tick;
                StateTransEvent -= _currentState.TransEvent;

                // 상태 클래스 비움
                _currentState = null;
            }

            OldStateType = CurrentStateType;

            // 상태 타입에 알맞은 상태 클래스로 변경
            switch (stateType)
            {
                case JellyStateType.Idle:
                    _currentState = _idleState;
                    break;
                case JellyStateType.Walk:
                    _currentState = _walkState;
                    break;

                default: return;
            }

            // 상태 액션 연결
            StateEnter += _currentState.Enter;
            StateExit += _currentState.Exit;
            StateTick += _currentState.Tick;
            StateTransEvent += _currentState.TransEvent;

            CurrentStateType = stateType;

            // 진입
            StateEnter.Invoke();
        }
    }
}