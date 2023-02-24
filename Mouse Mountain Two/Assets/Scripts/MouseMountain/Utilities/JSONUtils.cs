namespace MouseMountain.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class JsonUtils
    {
        public static T ImportJson<T>(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            return JsonUtility.FromJson<T>(textAsset.text);
        }
    }
}