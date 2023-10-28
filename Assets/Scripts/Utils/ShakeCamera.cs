using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using Cinemachine;

namespace Camera
{

    public class ShakeCamera : Singleton<ShakeCamera>
    {
        public CinemachineVirtualCamera virtualCamera;

        public float shakeTime;

        public void Shake(float amplitude, float frequency, float time)
        {
            var channel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            channel.m_AmplitudeGain = amplitude;
            channel.m_FrequencyGain = frequency;

            shakeTime = time;
        }

        private void Update()
        {
            if(shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
            }
            else
            {
                var channel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                channel.m_AmplitudeGain = 0f;
                channel.m_FrequencyGain = 0f;
            }
        }
    }
}
