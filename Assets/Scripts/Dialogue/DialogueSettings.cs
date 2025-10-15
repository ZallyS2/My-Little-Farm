using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string setences;

    public List<Setences> dialogues = new List<Setences>();

}

[System.Serializable]
public class Setences {
    public string actorName;
    public Sprite actorImage;
    public Languages sentences;
}

[System.Serializable]
public class Languages {
    public string english;
    public string portuguese;
}


//#if UNITY_EDITOR
//[CustomEditor(typeof(DialogueSettings))]
//public class BuilderEditor : Editor {
//    public override void OnInspectorGUI() {
//        DrawDefaultInspector();
//        DialogueSettings ds = (DialogueSettings)target;
        
        
//        Languages l = new Languages();
//        l.portuguese = ds.setences;
        
        
//        Setences s = new Setences();
//        s.sentences = l;
//        s.actorImage = ds.speakerSprite;

//        if (GUILayout.Button("Add Dialogue")) {
//            ds.dialogues.Add(s);
//            ds.speakerSprite = null;
//            ds.setences = "";
//            //EditorUtility.SetDirty(ds);*
//        }
//    }
//}
//#endif