using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabWindow : EditorWindow
{

    GameObject myPrefab;
    Vector3 objPos;
    
    [MenuItem("Personal Tools/Prefab Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PrefabWindow>("Prefab Editor");
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        myPrefab = EditorGUILayout.ObjectField("Prefab",myPrefab, typeof(GameObject), false) as GameObject;
        objPos = EditorGUILayout.Vector3Field("Object Position", objPos);
        
        if (GUI.Button(new Rect(new Vector2(5, 70),new Vector2(70,45)), "Click me"))
        {

            Debug.Log("Button clicked");
            if (myPrefab != null)
            {
                Instantiate(myPrefab, objPos, Quaternion.identity);
            }
            else
            {
                Debug.Log("Prefab empty!");
            }
        }

        if(GUI.Button(new Rect(new Vector2(100, 70), new Vector2(150, 45)), "Randomize pos btw 1-10"))
        {
            objPos.Set(Random.Range(0, 10), 0,0);
        }

        EditorGUILayout.EndVertical();
    }
}
