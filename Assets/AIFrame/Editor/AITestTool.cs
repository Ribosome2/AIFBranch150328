﻿using System.Runtime.Remoting.Services;
using UnityEngine;
using System.Collections;
using UnityEditor;
public class AITestWnd : EditorWindow {
    [MenuItem("AIFrame/Open/TestTool")]
	static void Start ()
    {
        AITestWnd wnd = EditorWindow.GetWindow<AITestWnd>();
    }

    private string aiModelName="Knight100";
    private int aiDataId =1000;
    public EAiCamp createCamp;
    private bool createAsAI;

    void OnGUI() 
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Load File New"))
        {
            AIDataMgr.instance.LoadNewData();
        }
        if(GUILayout.Button("ClearAllAI",GUILayout.Width(100)))
        {
            AIMgr.instance.DestroyAllAIs();
        }
        if (GUILayout.Button("DebugWindow", GUILayout.Width(100)))
        {
            AIDebugWindow.Open();
        }

        GUILayout.EndHorizontal();

       
        createCamp = (EAiCamp) EditorGUILayout.EnumPopup("创建阵营", createCamp);
        createAsAI = EditorGUILayout.Toggle("asAi", createAsAI);
        GUILayout.BeginHorizontal();
        aiModelName = AIFUIUtility.DrawTextField(aiModelName, "AI资源名");
        aiDataId = EditorGUILayout.IntField("AI数据ID", aiDataId);
        GUILayout.EndHorizontal();
         GUILayout.BeginHorizontal();
        if (GUILayout.Button("Create"))
        {
            CreateAI(aiModelName,aiDataId,createCamp,createAsAI);
        }

        if (GUILayout.Button("CreateEnemy"))
        {
            CreateAI(aiModelName, aiDataId, EAiCamp.Enemy, true);
        }
        GUILayout.EndHorizontal();


    }

    void CreateAI(string modelName, int aiId, EAiCamp camp, bool asAI)
    {
        AIUnit ai = AIMgr.instance.CreateAI(modelName, aiId);
        ai.aiCamp = camp;
        ai.SwitchAI(asAI);
    }


}
