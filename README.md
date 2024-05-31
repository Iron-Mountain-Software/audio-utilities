# Audio Utilities
*Version: 1.1.1*
## Description: 
A library of tools and components that work with Unity's audio system.
## Package Mirrors: 
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/audio-utilities)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/audio-utilities.git)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>](https://www.npmjs.com/package/com.iron-mountain.audio-utilities)
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
