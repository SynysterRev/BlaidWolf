#if UNITY_EDITOR

using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ScriptSettings : ScriptableObject
{
    public string ScriptName = "";
    public string NameSpace = "";
    public string FolderPath = "Assets\\";
    public string DeriveFrom = "MonoBehaviour";

    [Header("Regions")]
    public bool StructClassEnumRegion = false;
    public bool PublicFieldRegion = true;
    public bool ProtectedFieldRegion = false;
    public bool PrivateFieldRegion = true;
    public bool AccessorsRegion = true;
    public bool MonoBehaviourMethodsRegion = true;
    public bool OverrideMethodsRegion = false;
    public bool InterfacesMethodsRegion = false;
    public bool PublicMethodsRegion = true;
    public bool ProtectedMethodsRegion = false;
    public bool PrivateMethodsRegion = true;


    [Header("MonoBehaviour Methods")]
    public bool Awake = false;
    public bool OnEnable = false;
    public bool Start = true;
    public bool Update = true;
    public bool FixedUpdate = false;
    public bool LateUpdate = false;
    public bool OnDisable = false;

    public bool OnCollisionEnter = false;
    public bool OnCollisionEnter2D = false;
    public bool OnCollisionExit = false;
    public bool OnCollisionExit2D = false;
    public bool OnCollisionStay = false;
    public bool OnCollisionStay2D = false;

    public bool OnTriggerEnter = false;
    public bool OnTriggerEnter2D = false;
    public bool OnTriggerExit = false;
    public bool OnTriggerExit2D = false;
    public bool OnTriggerStay = false;
    public bool OnTriggerStay2D = false;
}

[CustomEditor(typeof(ScriptSettings))]
public class LookAtPointEditor : Editor
{
    ScriptSettings scriptSettings;
    Vector2 scrollPos;
    static bool foldoutClass = true;
    static bool foldoutRegion = true;
    static bool foldoutMonoBehaviourMethods = true;

    private void OnEnable()
    {
        scriptSettings = target as ScriptSettings;
    }

    public override void OnInspectorGUI()
    {

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);


        EditorGUILayout.Space(10f);
        foldoutClass = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutClass, "Class", EditorStyles.foldoutHeader);
        if (foldoutClass)
        {
            EditorGUILayout.Space(5f);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(10f, false);
            EditorGUILayout.BeginVertical();
            scriptSettings.ScriptName = EditorGUILayout.TextField("ScriptName", scriptSettings.ScriptName);
            scriptSettings.NameSpace = EditorGUILayout.TextField("NameSpace", scriptSettings.NameSpace);
            scriptSettings.FolderPath = EditorGUILayout.TextField("FolderPath", scriptSettings.FolderPath);
            scriptSettings.DeriveFrom = EditorGUILayout.TextField("DeriveFrom", scriptSettings.DeriveFrom);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(10f);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();


        foldoutRegion = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutRegion, "Regions", EditorStyles.foldoutHeader);
        if (foldoutRegion)
        {
            EditorGUILayout.Space(5f);
            EditorGUILayout.BeginHorizontal(EditorStyles.boldLabel);
            EditorGUILayout.Space(10f, false);
            EditorGUILayout.BeginVertical();
            scriptSettings.StructClassEnumRegion = EditorGUILayout.Toggle("StructClassEnum", scriptSettings.StructClassEnumRegion);
            scriptSettings.PublicFieldRegion = EditorGUILayout.Toggle("PublicField", scriptSettings.PublicFieldRegion);
            scriptSettings.ProtectedFieldRegion = EditorGUILayout.Toggle("ProtectedField", scriptSettings.ProtectedFieldRegion);
            scriptSettings.PrivateFieldRegion = EditorGUILayout.Toggle("PrivateField", scriptSettings.PrivateFieldRegion);
            scriptSettings.AccessorsRegion = EditorGUILayout.Toggle("Accessors", scriptSettings.AccessorsRegion);
            scriptSettings.MonoBehaviourMethodsRegion = EditorGUILayout.Toggle("MonoBehaviourMethods", scriptSettings.MonoBehaviourMethodsRegion);
            scriptSettings.OverrideMethodsRegion = EditorGUILayout.Toggle("OverrideMethods", scriptSettings.OverrideMethodsRegion);
            scriptSettings.InterfacesMethodsRegion = EditorGUILayout.Toggle("InterfacesMethods", scriptSettings.InterfacesMethodsRegion);
            scriptSettings.PublicMethodsRegion = EditorGUILayout.Toggle("PublicMethods", scriptSettings.PublicMethodsRegion);
            scriptSettings.ProtectedMethodsRegion = EditorGUILayout.Toggle("ProtectedMethods", scriptSettings.ProtectedMethodsRegion);
            scriptSettings.PrivateMethodsRegion = EditorGUILayout.Toggle("PrivateMethods", scriptSettings.PrivateMethodsRegion);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(10f);

        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        foldoutMonoBehaviourMethods = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutMonoBehaviourMethods, "MonoBehaviourMethods", EditorStyles.foldoutHeader);
        if (foldoutMonoBehaviourMethods)
        {
            EditorGUILayout.Space(5f);
            EditorGUILayout.BeginHorizontal(EditorStyles.boldLabel);
            EditorGUILayout.Space(10f, false);
            EditorGUILayout.BeginVertical();
            scriptSettings.Awake = EditorGUILayout.Toggle("Awake", scriptSettings.Awake);
            scriptSettings.OnEnable = EditorGUILayout.Toggle("OnEnable", scriptSettings.OnEnable);
            scriptSettings.Start = EditorGUILayout.Toggle("Start", scriptSettings.Start);
            scriptSettings.Update = EditorGUILayout.Toggle("Update", scriptSettings.Update);
            scriptSettings.FixedUpdate = EditorGUILayout.Toggle("FixedUpdate", scriptSettings.FixedUpdate);
            scriptSettings.LateUpdate = EditorGUILayout.Toggle("LateUpdate", scriptSettings.LateUpdate);
            scriptSettings.OnDisable = EditorGUILayout.Toggle("OnDisable", scriptSettings.OnDisable);

            scriptSettings.OnCollisionEnter = EditorGUILayout.Toggle("OnCollisionEnter", scriptSettings.OnCollisionEnter);
            scriptSettings.OnCollisionEnter2D = EditorGUILayout.Toggle("OnCollisionEnter2D", scriptSettings.OnCollisionEnter2D);
            scriptSettings.OnCollisionExit = EditorGUILayout.Toggle("OnCollisionExit", scriptSettings.OnCollisionExit);
            scriptSettings.OnCollisionExit2D = EditorGUILayout.Toggle("OnCollisionExit2D", scriptSettings.OnCollisionExit2D);
            scriptSettings.OnCollisionStay = EditorGUILayout.Toggle("OnCollisionStay", scriptSettings.OnCollisionStay);
            scriptSettings.OnCollisionStay2D = EditorGUILayout.Toggle("OnCollisionStay2D", scriptSettings.OnCollisionStay2D);

            scriptSettings.OnTriggerEnter = EditorGUILayout.Toggle("OnTriggerEnter", scriptSettings.OnTriggerEnter);
            scriptSettings.OnTriggerEnter2D = EditorGUILayout.Toggle("OnTriggerEnter2D", scriptSettings.OnTriggerEnter2D);
            scriptSettings.OnTriggerExit = EditorGUILayout.Toggle("OnTriggerExit", scriptSettings.OnTriggerExit);
            scriptSettings.OnTriggerExit2D = EditorGUILayout.Toggle("OnTriggerExit2D", scriptSettings.OnTriggerExit2D);
            scriptSettings.OnTriggerStay = EditorGUILayout.Toggle("OnTriggerStay", scriptSettings.OnTriggerStay);
            scriptSettings.OnTriggerStay2D = EditorGUILayout.Toggle("OnTriggerStay2D", scriptSettings.OnTriggerStay2D);

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(10f);
        }
        if (scriptSettings.Awake || scriptSettings.OnEnable || scriptSettings.Start || scriptSettings.Update ||
            scriptSettings.FixedUpdate || scriptSettings.LateUpdate || scriptSettings.OnDisable)
        {
            scriptSettings.MonoBehaviourMethodsRegion = true;
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        EditorGUILayout.Space(10f);
        EditorGUILayout.EndVertical();

    }
}

public class ScriptCreatorWindows : EditorWindow
{

    ScriptSettings scriptSettings;
    ScriptCreatorWindows windows;
    Vector2 scrollPos;

    [MenuItem("Window/ScriptCreator %q")]
    [MenuItem("Assets/Create/ScriptCreator", false, 80)]
    public static void ShowWindow()
    {
        GetWindow(typeof(ScriptCreatorWindows));
    }
    string FindCurrentFolderPath()
    {
        Type projectWindowUtilType = typeof(ProjectWindowUtil);
        MethodInfo getActiveFolderPath = projectWindowUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
        object obj = getActiveFolderPath.Invoke(null, new object[0]);
        string pathToCurrentFolder = obj.ToString();
        return pathToCurrentFolder + "/";
    }
    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        if (scriptSettings == null)
        {
            scriptSettings = new ScriptSettings();
            scriptSettings.FolderPath = FindCurrentFolderPath();
        }

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true, GUIStyle.none, GUI.skin.verticalScrollbar, GUIStyle.none);
        var editor = Editor.CreateEditor(scriptSettings);
        if (editor != null)
        {
            editor.OnInspectorGUI();
        }
        EditorGUILayout.EndScrollView();

        GUILayout.Space(5f);
        if (GUILayout.Button("Create script"))
        {
            CreateScript(scriptSettings);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        // The actual window code goes here
    }

    public bool CreateScript(ScriptSettings scriptSettings)
    {

        string name = scriptSettings.ScriptName.Replace(" ", "_");
        name = name.Replace("-", "_");
        string copyPath = scriptSettings.FolderPath + name + ".cs";
        Debug.Log("Creating Classfile: " + copyPath);
        if (File.Exists(copyPath) == false)
        { // do not overwrite

            using (StreamWriter outfile =
                new StreamWriter(copyPath))
            {
                outfile.WriteLine("using UnityEngine;");
                outfile.WriteLine("using System.Collections;");
                outfile.WriteLine("");

                if (scriptSettings.NameSpace != "")
                {
                    outfile.WriteLine("namespace " + scriptSettings.NameSpace);
                    outfile.WriteLine("{");
                }

                string baseClassName = scriptSettings.DeriveFrom != "" ? " : " + scriptSettings.DeriveFrom : "";
                outfile.WriteLine("public class " + name + baseClassName);
                outfile.WriteLine("{");
                outfile.WriteLine("");

                if (scriptSettings.StructClassEnumRegion)
                {
                    outfile.WriteLine("\t#region Structs, classes and enums");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.PublicFieldRegion)
                {
                    outfile.WriteLine("\t#region Public Fields");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.ProtectedFieldRegion)
                {
                    outfile.WriteLine("\t#region Protected Fields");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.PrivateFieldRegion)
                {
                    outfile.WriteLine("\t#region Private Fields");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.AccessorsRegion)
                {
                    outfile.WriteLine("\t#region Accessors");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.MonoBehaviourMethodsRegion)
                {
                    outfile.WriteLine("\t#region MonoBehaviour Methods");
                    outfile.WriteLine("");
                }

                WriteMonoBehaviourMethods(scriptSettings, outfile);

                if (scriptSettings.MonoBehaviourMethodsRegion)
                {
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.OverrideMethodsRegion)
                {
                    outfile.WriteLine("\t#region Override Methods");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.InterfacesMethodsRegion)
                {
                    outfile.WriteLine("\t#region Interfaces Methods");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.PrivateMethodsRegion)
                {
                    outfile.WriteLine("\t#region Private Methods");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.ProtectedMethodsRegion)
                {
                    outfile.WriteLine("\t#region Protected Methods");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                if (scriptSettings.PublicMethodsRegion)
                {
                    outfile.WriteLine("\t#region Public Methods");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t#endregion");
                    outfile.WriteLine("");
                    outfile.WriteLine("");
                }

                outfile.WriteLine("}");

                if (scriptSettings.NameSpace != "")
                {
                    outfile.WriteLine("}");
                }
            }//File written
        }
        else
        {
            Debug.LogError("Can't create the script, another script have the same name");
            return false;
        }
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
        return true;
    }

    void WriteMonoBehaviourMethods(ScriptSettings scriptSettings, StreamWriter outfile)
    {
        if (scriptSettings.Awake)
        {
            outfile.WriteLine("\tvoid Awake()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnEnable)
        {
            outfile.WriteLine("\tvoid OnEnable()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
            outfile.WriteLine("");
        }

        if (scriptSettings.Start)
        {
            outfile.WriteLine("\tvoid Start()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
            outfile.WriteLine("");
        }

        if (scriptSettings.Update)
        {
            outfile.WriteLine("\tvoid Update()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.FixedUpdate)
        {
            outfile.WriteLine("\tvoid FixedUpdate()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.LateUpdate)
        {
            outfile.WriteLine("\tvoid LateUpdate()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnDisable)
        {
            outfile.WriteLine("\tvoid OnDisable()");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionEnter)
        {
            outfile.WriteLine("\tvoid OnCollisionEnter(Collision collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionEnter2D)
        {
            outfile.WriteLine("\tvoid OnCollisionEnter2D(Collision2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionExit)
        {
            outfile.WriteLine("\tvoid OnCollisionExit(Collision collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionExit2D)
        {
            outfile.WriteLine("\tvoid OnCollisionExit2D(Collision2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionStay)
        {
            outfile.WriteLine("\tvoid OnCollisionStay(Collision collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnCollisionStay2D)
        {
            outfile.WriteLine("\tvoid OnCollisionStay2D(Collision2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerEnter)
        {
            outfile.WriteLine("\tvoid OnTriggerEnter(Collider other)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerEnter2D)
        {
            outfile.WriteLine("\tvoid OnTriggerEnter2D(Collider2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerExit)
        {
            outfile.WriteLine("\tvoid OnTriggerExit(Collider other)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerExit2D)
        {
            outfile.WriteLine("\tvoid OnTriggerExit2D(Collider2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerStay)
        {
            outfile.WriteLine("\tvoid OnTriggerStay(Collider other)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }

        if (scriptSettings.OnTriggerStay2D)
        {
            outfile.WriteLine("\tvoid OnTriggerStay2D(Collider2D collision)");
            outfile.WriteLine("\t{");
            outfile.WriteLine("");
            outfile.WriteLine("\t}");
            outfile.WriteLine("");
        }
    }
}

#endif