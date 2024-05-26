using UnityEditor;
using UnityEngine;

public class RemoveMissingScripts : EditorWindow
{
    [MenuItem("Tools/Remove Missing Scripts from Scene")]
    public static void ShowWindow()
    {
        GetWindow<RemoveMissingScripts>("Remove Missing Scripts");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Remove Missing Scripts from All GameObjects"))
        {
            RemoveMissingScriptsFromAll();
        }
    }

    private static void RemoveMissingScriptsFromAll()
    {
        int count = 0;
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            count += RemoveMissingScriptsFromGameObject(obj);
        }
        Debug.Log($"Removed {count} missing scripts from GameObjects in the scene.");
    }

    private static int RemoveMissingScriptsFromGameObject(GameObject obj)
    {
        int initialComponentCount = obj.GetComponents<Component>().Length;

        // Use GameObjectUtility to remove missing scripts
        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);

        int finalComponentCount = obj.GetComponents<Component>().Length;
        return initialComponentCount - finalComponentCount;
    }
}
