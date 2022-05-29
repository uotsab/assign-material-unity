# Introduction:
A easy and straightforward tool for assigning materials to an object in C# for Unity

![image](https://user-images.githubusercontent.com/59441459/170861023-a555cc16-ee3f-431e-aad8-93ac35317b48.png)


## Opening the window:
1. At top, open the strip menu item "Widnow"
2. Hover mouse "Uotsab Windows"
3. Lastly select "Material Assigner" window
Now if things are alright, You would see the material assigner window for Unity


## Example: assign green:

Make sure "Material Assigner" window is open. If not, so follow the avove aprragraph to open it.

#### 1. Select your desired Material. Green Material in case of the example here...

![image](https://user-images.githubusercontent.com/59441459/170860429-629ed18b-1008-438c-883a-80abafd404e5.png)

#### 2. Click On "Material To Assign" in "Assign Material" window 

![image](https://user-images.githubusercontent.com/59441459/170860477-3f1bee4e-b3e7-469f-9af5-ef48e3d6b5ed.png)

#### 3. Select your GameObject (Or Prefabs too!). Press "Objects to assign on"

![image](https://user-images.githubusercontent.com/59441459/170860610-e4a003aa-546d-4db5-80a3-3e03bb4124b4.png)

#### 4. Lastly magic, just click "Assign Material" and it should do!!!
![image](https://user-images.githubusercontent.com/59441459/170860856-4dc161c0-7fdd-43ad-b602-0db70b47d6f2.png)



## Structure:

The project is kept as ssimple as possible for any programmers to understand. But here's yet a quick explaination of the Script:

The asset contains only and only one script file that does the job. It is "Material-Assigner.cs".

```
static void ShowWindow() { }
```
This Method creates the window
```
[MenuItem("Window/Uotsab Windows/Material Assigner")] - 
```
Will set a path to Unity's strip menu to open the Material Assigner
```
GetWindow<MaterialAssigner>("Assign Material");
```
Makes Window of classs "MaterialAssigner"

```
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
```
Creates Button to assign material in materialToAssign variable
```

        GUILayout.Label("2. Select objects to asssign material on.");
        if(GUILayout.Button("Objects to assign on"))
        {
            objects.Clear();
            foreach (Object obj in Selection.objects)
            {
                objects.Add(obj);
            }
        }
 ```
Creates Button to assign objects in "objects" List<GameObject>() variable
  ```
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
  ```
  Finally creates a button to assign "materialToAssign" material to all the objects in "objects" List<> variable.

![image](https://user-images.githubusercontent.com/59441459/170861006-dcf09248-6fd1-453f-b7d9-70b463c25f34.png)
