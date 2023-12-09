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
            if (mixerGroup)
            {
                slider.minValue = mixerGroup.MinimumVolume;
                slider.maxValue = mixerGroup.MaximumVolume;
                slider.value = mixerGroup.Volume;
            }
            else
            {
                slider.minValue = ScriptedAudioMixerGroup.AbsoluteMinimumVolume;
                slider.maxValue = ScriptedAudioMixerGroup.AbsoluteMaximumVolume;
                slider.value = 0f;
            }
        }

        private void OnValueChanged(float value)
        {
            if (mixerGroup) mixerGroup.Volume = value;
        }
    }
}