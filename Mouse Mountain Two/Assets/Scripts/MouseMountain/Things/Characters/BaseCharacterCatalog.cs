using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MouseMountain.Things.Characters
{
    public class BaseCharacterCatalog : MonoBehaviour
    {
        public GameObject owlArch;
        public GameObject testMouse;
        
        public Dictionary<string, GameObject> CharacterCatalog = new FlexibleDictionary<string, GameObject>();
        public static BaseCharacterCatalog Instance { get; private set; }
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
            CharacterCatalog.Add("OWLARCH", owlArch);
            CharacterCatalog.Add("TESTMOUSE", testMouse);
        }
    }
}