using System;
using UnityEngine;
using UnityEngine.Audio;

namespace IronMountain.AudioUtilities
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Audio/Audio Mixer Group")]
    public class ScriptedAudioMixerGroup : ScriptableObject
    {
        public event Action OnVolumeChanged;
        
        public const float MinimumVolume = -80f;
        public const float MaximumVolume = 20f;
        
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string playerPrefsKey = "Audio Mixer Group Volume";
        [SerializeField] private string volumePropertyName = "Volume";
        
        public float Volume
        {
            get => PlayerPrefs.GetFloat(playerPrefsKey, 0);
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
        }
        
        public void RefreshAudioMixer()
        {
            if (!audioMixer) return;
            float volume = GloballyMutedManager.GloballyMuted ? MinimumVolume : Volume;
            audioMixer.SetFloat(volumePropertyName, volume);
        }
    }
}
