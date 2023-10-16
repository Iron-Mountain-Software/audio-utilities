using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AudioUtilities
{
    [RequireComponent(typeof(Toggle))]
    public class GloballyMutedToggle : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;

        private void Awake()
        {
            if (!toggle) toggle = GetComponent<Toggle>();
        }

        private void OnValidate()
        {
            if (!toggle) toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            GloballyMutedManager.OnGloballyMutedChanged += RefreshToggle;
            RefreshToggle();
            if (toggle) toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnDisable()
        {
            GloballyMutedManager.OnGloballyMutedChanged -= RefreshToggle;
            if (toggle) toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool value)
        {
            GloballyMutedManager.GloballyMuted = value;
        }

        private void RefreshToggle()
        {
            if (toggle) toggle.isOn = GloballyMutedManager.GloballyMuted;
        }
    }
}
