using GoldMetal_Jelly;
using UnityEngine;

public interface IJellyState
{
    void Enter();   // 진입 시
    void Tick();    // 상태 유지 시, 갱신
    void Exit();    // 탈출 시
    JellyStateType TransEvent();
}
