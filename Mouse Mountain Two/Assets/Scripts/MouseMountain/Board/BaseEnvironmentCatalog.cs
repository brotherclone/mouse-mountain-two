using System.Collections.Generic;
using UnityEngine;

namespace MouseMountain.Board
{
    public class BaseEnvironmentCatalog: MonoBehaviour
    {
        
        public Material cave1Material;
        public Material otherMaterial;
        public AudioClip caveAmbientSound;
        public readonly Dictionary<string, Material> SkyboxCatalog = new Dictionary<string, Material>();
        public readonly Dictionary<string, AudioClip> AmbientLoopCatalog = new Dictionary<string, AudioClip>();
        public static BaseEnvironmentCatalog Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            SkyboxCatalog.Add("cave_1", cave1Material);
            SkyboxCatalog.Add("test_box", otherMaterial);
            AmbientLoopCatalog.Add("cave_sounds_1", caveAmbientSound);
        }
    }
}