using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace IronMountain.AudioUtilities
{
    [RequireComponent(typeof(Slider))]
    public class SimpleAudioMixerGroupSlider : MonoBehaviour
    {
        [SerializeField] private float minimumValue = -80f;
        [SerializeField] private float maximumValue = 20f;
        [SerializeField] private string propertyName = "Volume";
        [SerializeField] private AudioMixer mixer;
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
            if (!slider) return;
            slider.minValue = minimumValue;
            slider.maxValue = maximumValue;
            mixer.GetFloat(propertyName, out float value);
            slider.value = value;
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            if (!slider) return;
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float soundLevel)
        {
            mixer.SetFloat(propertyName, soundLevel);
        }
    }
}