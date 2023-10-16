using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AudioUtilities
{
    [RequireComponent(typeof(Slider))]
    public class ScriptedAudioMixerGroupVolumeSlider : MonoBehaviour
    {
        [SerializeField] private ScriptedAudioMixerGroup mixerGroup;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            if (!slider) slider = GetComponent<Slider>();
        }
    
        private void OnValidate()
        {
            if (!slider) slider = GetComponent<Slider>();
        }
    
        private void OnEnable()
        {
            if (mixerGroup) mixerGroup.OnVolumeChanged += RefreshSlider;
            RefreshSlider();
            if (slider) slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            if (mixerGroup) mixerGroup.OnVolumeChanged -= RefreshSlider;
            if (slider) slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void RefreshSlider()
        {
            if (!slider) return;
            slider.minValue = ScriptedAudioMixerGroup.MinimumVolume;
            slider.maxValue = ScriptedAudioMixerGroup.MaximumVolume;
            slider.value = mixerGroup ? mixerGroup.Volume : 0;
        }

        private void OnValueChanged(float value)
        {
            if (mixerGroup) mixerGroup.Volume = value;
        }
    }
}