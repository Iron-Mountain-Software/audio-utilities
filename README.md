# Audio Utilities
*Version: 1.1.0*
## Description: 
A library of tools and components that work with Unity's audio system.
---
## Key Scripts & Components: 
1. public class **AudioManager** : MonoBehaviour
1. public static class **GloballyMutedManager**
1. public class **GloballyMutedToggle** : MonoBehaviour
1. public class **ScriptedAudioMixerGroup** : ScriptableObject
   * Actions: 
      * public event Action ***OnVolumeChanged*** 
   * Properties: 
      * public float ***MinimumVolume***  { get; }
      * public float ***MaximumVolume***  { get; }
      * public float ***Volume***  { get; set; }
   * Methods: 
      * public void ***RefreshAudioMixer***()
1. public class **ScriptedAudioMixerGroupVolumeSlider** : MonoBehaviour
1. public class **SimpleAudioMixerGroupSlider** : MonoBehaviour
