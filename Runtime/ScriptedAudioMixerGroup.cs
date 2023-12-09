using System;
using UnityEngine;
using UnityEngine.Audio;

namespace IronMountain.AudioUtilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Audio/Audio Mixer Group")]
    public class ScriptedAudioMixerGroup : ScriptableObject
    {
        public event Action OnVolumeChanged;
        
        public const float AbsoluteMinimumVolume = -80f;
        public const float AbsoluteMaximumVolume = 20f;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] [Range(AbsoluteMinimumVolume, AbsoluteMaximumVolume)] private float minimumVolume = -20;
        [SerializeField] [Range(AbsoluteMinimumVolume, AbsoluteMaximumVolume)] private float maximumVolume = 10;
        [SerializeField] [Range(AbsoluteMinimumVolume, AbsoluteMaximumVolume)] private float defaultVolume = 0;
        [SerializeField] private string playerPrefsKey = "Audio Mixer Group Volume";
        [SerializeField] private string volumePropertyName = "Volume";

        public float MinimumVolume => minimumVolume;
        public float MaximumVolume => maximumVolume;
        
        public float Volume
        {
            get => PlayerPrefs.GetFloat(playerPrefsKey, defaultVolume);
            set
            {
                value = Mathf.Clamp(value, MinimumVolume, MaximumVolume);
                PlayerPrefs.SetFloat(playerPrefsKey, value);
                RefreshAudioMixer();
                OnVolumeChanged?.Invoke();
            }
        }

        private void OnEnable()
        {
            GloballyMutedManager.OnGloballyMutedChanged += RefreshAudioMixer;
            RefreshAudioMixer();
        }

        private void OnDisable()
        {
            GloballyMutedManager.OnGloballyMutedChanged -= RefreshAudioMixer;
        }

        private void OnValidate()
        {
            RefreshAudioMixer();
            minimumVolume = Mathf.Clamp(minimumVolume, AbsoluteMinimumVolume, AbsoluteMaximumVolume);
            maximumVolume = Mathf.Clamp(maximumVolume, minimumVolume, AbsoluteMaximumVolume);
            defaultVolume = Mathf.Clamp(defaultVolume, minimumVolume, maximumVolume);
        }
        
        public void RefreshAudioMixer()
        {
            if (!audioMixer) return;
            float volume = GloballyMutedManager.GloballyMuted ? AbsoluteMinimumVolume : Volume;
            audioMixer.SetFloat(volumePropertyName, volume);
        }
    }
}
