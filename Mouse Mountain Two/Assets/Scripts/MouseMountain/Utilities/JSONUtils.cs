namespace MouseMountain.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class JSONUtils
    {
        public static T ImportJSON<T>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<T>(textAsset.text);
        }
    }
}