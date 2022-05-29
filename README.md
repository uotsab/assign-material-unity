# Introduction:
A easy and straightforward tool for assigning materials to an object in *C#* for *Unity*

![image](https://user-images.githubusercontent.com/59441459/170861023-a555cc16-ee3f-431e-aad8-93ac35317b48.png)

Will assign you one material to multiple (Or hundrades+) objects without dragging and dropping the material to one by one of those objects.

## **Getting it to Unity:**
Make sure you're in the github page of this asset https://github.com/uotsab/assign-material-unity

**1.**

![image](https://user-images.githubusercontent.com/59441459/170861810-cfa9d272-c43e-4501-9383-854606faac19.png)

Download Zip file. 

(You can also clone by the way. You'd need to have "Git" installed in your machine on that case. You'll copy the link like shown below:)

![image](https://user-images.githubusercontent.com/59441459/170861864-80cfe13a-350a-431a-8643-a4c0a01bb1df.png)

**2.**

![image](https://user-images.githubusercontent.com/59441459/170862037-7337c237-2d71-4521-b346-cd95b4fd40f1.png)

Extract with *[WinRar](https://www.win-rar.com/start.html?&L=0)* software

**3.**

![image](https://user-images.githubusercontent.com/59441459/170862496-fe593fd0-c7e4-4da5-84f9-5e7ee56bf12e.png)

New folder has been created. That is the place WinRar extracted the project. The name of the folder is - *assign-material-unity-main*. Now, open it.

**4.**

![image](https://user-images.githubusercontent.com/59441459/170862283-98e2678b-77c3-4459-8e2a-90f0095c40ac.png)

Inside from the folder, drag and drop *MaterialAssigner.cs* in Unity Project Manager.

Now, Unity will automatically function the Script in the Editor strip menu.



## **Opening the window:**
This is how you'll open material assigner inside unity:
1. At top, open the Unity's strip menu item "Window"
2. Hover mouse "Uotsab Windows"
3. Lastly select "Material Assigner" window
Now if things are alright, You would see the material assigner window for Unity


## **Example: 01 Assign green materials:**

Make sure "Material Assigner" window is open. If not, so follow the avove parragraph to open it.

#### 1. Select your desired Material. Green Material in case of the example here...

![image](https://user-images.githubusercontent.com/59441459/170860429-629ed18b-1008-438c-883a-80abafd404e5.png)

#### 2. Click On "Material To Assign" in "Assign Material" window 

![image](https://user-images.githubusercontent.com/59441459/170860477-3f1bee4e-b3e7-469f-9af5-ef48e3d6b5ed.png)

#### 3. Select your GameObject (Or Prefabs too!). Press "Objects to assign on"

![image](https://user-images.githubusercontent.com/59441459/170860610-e4a003aa-546d-4db5-80a3-3e03bb4124b4.png)

#### 4. Lastly magic, just click "Assign Material" and it should do!!!
![image](https://user-images.githubusercontent.com/59441459/170860856-4dc161c0-7fdd-43ad-b602-0db70b47d6f2.png)

This assigned Green Material to all the objects that were selected. And the selected objects are colored green by the material.
So now you saw multiple objects got the material assigned without of Dragging and Dropping one after one of the objects. Bravo!!!!!!


## **Structure:**

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
