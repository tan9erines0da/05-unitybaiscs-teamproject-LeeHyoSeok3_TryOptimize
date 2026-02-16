using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PerformanceMonitor : MonoBehaviour
{
    public static PerformanceMonitor Instance;
    
    private Stopwatch _sw = new Stopwatch();
    
    public long TotalTicksThisFrame { get; private set; }
    private bool _hasMeasuredThisFrame = false;

    // 평균 계산을 위한 변수들
    private long _accumulatedTicks = 0;
    private int _measuredFrameCount = 0;

    void Awake() => Instance = this;

    public void BeginMeasure() => _sw.Restart();

    public void EndMeasure()
    {
        _sw.Stop();
        TotalTicksThisFrame += _sw.ElapsedTicks;
        _hasMeasuredThisFrame = true;
    }

    void LateUpdate()
    {
        if (_hasMeasuredThisFrame)
        {
            _measuredFrameCount++;
            _accumulatedTicks += TotalTicksThisFrame;

            // 현재 프레임 수치 (ms 변환)
            double currentMs = TicksToMs(TotalTicksThisFrame);
            
            // 누적 평균 수치 (ms 변환)
            double averageMs = TicksToMs(_accumulatedTicks / _measuredFrameCount);

            UnityEngine.Debug.Log(
                $"[Frame {Time.frameCount}] " +
                $"Current: {currentMs:F4}ms | " +
                $"Average({_measuredFrameCount} frames): {averageMs:F4}ms"
            );
            
            // 프레임 데이터 리셋
            TotalTicksThisFrame = 0;
            _hasMeasuredThisFrame = false;
        }
    }

    // Ticks를 ms로 변환하는 공통 함수
    private double TicksToMs(long ticks)
    {
        return (double)ticks / Stopwatch.Frequency * 1000;
    }

    // 필요 시 평균 데이터를 초기화하는 함수 (예: 리스트에서 딕셔너리로 테스트 모드를 바꿀 때 호출)
    // public void ResetAverage()
    // {
    //     _accumulatedTicks = 0;
    //     _measuredFrameCount = 0;
    //     UnityEngine.Debug.Log("Performance Average Reset.");
    // }
}