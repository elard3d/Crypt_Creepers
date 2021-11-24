using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;

    private CinemachineBasicMultiChannelPerlin noise;
    
    void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
    }

    public void Shake(float duration = 0.1f, float amplitude = 1.5f, float frecuency = 20)
    {
        StopAllCoroutines();
        StartCoroutine(ApplyNoiseRoutine(duration,amplitude,frecuency));
    }

    IEnumerator ApplyNoiseRoutine(float duration = 0.1f, float amplitude = 1.5f, float frecuency = 20)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frecuency;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
