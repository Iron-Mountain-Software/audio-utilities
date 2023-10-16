using System.Collections.Generic;
using UnityEngine;

namespace IronMountain.AudioUtilities
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private bool dontDestroyOnLoad = true;
        [SerializeField] private List<ScriptedAudioMixerGroup> groups = new();

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else
            {
                Instance = this;
                if (dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance != this) return;
            Instance = null;
        }

        private void Start()
        {
            foreach (ScriptedAudioMixerGroup scriptedAudioMixerGroup in groups)
            {
                if (!scriptedAudioMixerGroup) continue;
                scriptedAudioMixerGroup.RefreshAudioMixer();
            }
        }
    }
}
