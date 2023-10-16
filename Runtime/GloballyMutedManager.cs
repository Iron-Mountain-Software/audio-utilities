using System;
using UnityEngine;

namespace IronMountain.AudioUtilities
{
    public static class GloballyMutedManager
    {
        public static event Action OnGloballyMutedChanged; 
        
        private const string GlobalMutedPlayerPrefsKey = "Globally Muted";
        
        public static bool GloballyMuted
        {
            get => PlayerPrefs.GetInt(GlobalMutedPlayerPrefsKey, 0) == 1;
            set
            {
                PlayerPrefs.SetInt(GlobalMutedPlayerPrefsKey, value ? 1 : 0);
                OnGloballyMutedChanged?.Invoke();
            }
        }
    }
}