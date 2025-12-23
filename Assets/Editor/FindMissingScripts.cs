using UnityEditor;
using UnityEngine;

public class FindMissingScripts
{
    [MenuItem("Tools/Find Missing Scripts")]
    static void Find()
    {
        GameObject[] gos = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var go in gos)
        {
            var components = go.GetComponents<Component>();
            foreach (var c in components)
            {
                if (c == null)
                {
                    Debug.LogError("Missing script found on: " + go.name, go);
                }
            }
        }
    }
}
