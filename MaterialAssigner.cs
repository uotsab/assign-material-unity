using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialAssigner : EditorWindow
{
    [SerializeField]
    List<Object> objects;

    Material materialToAssign;

    [MenuItem("Window/Uotsab Windows/Material Assigner")]
    public static void ShowWindow()
    {
        GetWindow<MaterialAssigner>("Assign Material");
    }

    private void OnGUI() {
        GUILayout.Label("1. Select material that will be assigned.");
        if(GUILayout.Button("Material To Assign"))
        {
            foreach (Object obj in Selection.objects)
            {
                if(obj.GetType() == typeof(Material))
                {
                    materialToAssign = (Material)obj;
                }
            }
        }
        GUILayout.Label("2. Select objects to asssign material on.");
        if(GUILayout.Button("Objects to assign on"))
        {
            objects.Clear();
            foreach (Object obj in Selection.objects)
            {
                objects.Add(obj);
            }
        }
        GUILayout.Label("3. Now click the button below:");
        if(GUILayout.Button("Assign Material"))
        {
            if(objects == null)
            {
                if(Selection.objects == null)
                {
                    Debug.LogError("There are no objects assigned and nothing is selected");
                }
                else
                {
                    foreach(GameObject obj in Selection.objects)
                    {
                        objects.Add(obj);
                    }
                }
            }
            foreach(GameObject obj in objects)
            {
                obj.GetComponent<Renderer>().material = materialToAssign;
            }
        }
        GUILayout.Label("Selected material :  " + materialToAssign.name);
    }
}
