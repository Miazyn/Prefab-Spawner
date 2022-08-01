using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabWindow : EditorWindow
{

    GameObject myPrefab;
    static Vector3 objPos;
    static Vector3 objScale;

    Vector3 lastPlacedPos;
    Vector3 lastPlacedScale;
    //Vector3 lastRotation;
    GameObject contentsRoot;
    GameObject lastPlacedObject;
    
    [MenuItem("Personal Tools/Prefab Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PrefabWindow>("Prefab Editor");
    }

    [InitializeOnLoadMethod]
    static void Init()
    {
        SceneView.duringSceneGui += SceneView_duringSceneGui;
    }

    private static void SceneView_duringSceneGui(SceneView obj)
    {
        Handles.color = Color.red;
        Handles.DrawWireCube(objPos, objScale);
        obj.Repaint();
    }

    private void OnGUI()
    {
        
        EditorGUILayout.BeginVertical();
        myPrefab = EditorGUILayout.ObjectField("Prefab",myPrefab, typeof(GameObject), false) as GameObject;
        objPos = EditorGUILayout.Vector3Field("Object Position", objPos);

        objScale = myPrefab != null ? myPrefab.transform.lossyScale : Vector3.zero;
        

        if (GUI.Button(new Rect(new Vector2(5, 70),new Vector2(70,45)), "Click me"))
        {
            if (myPrefab != null)
            {
                lastPlacedObject = (GameObject)PrefabUtility.InstantiatePrefab(myPrefab);

                Undo.RegisterCreatedObjectUndo(lastPlacedObject, "Undo Placed Prefab");

                lastPlacedObject.transform.position = objPos;
                lastPlacedObject.transform.rotation = Quaternion.identity;
                


                //SAVE EVERY DETAIL:
                lastPlacedPos = lastPlacedObject.transform.position;
                lastPlacedScale = lastPlacedObject.transform.lossyScale;
            }
            else
            {
                Debug.LogWarning("Prefab empty!");
            }
        }

        if(GUI.Button(new Rect(new Vector2(100, 70), new Vector2(150, 45)), "Randomize pos btw 1-10"))
        {
            //Randomize values

            objPos.Set(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        }

        
        EditorGUILayout.EndVertical();

    }


}
