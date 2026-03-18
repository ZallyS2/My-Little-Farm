using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentences;
    public string name;

    public List<Sentences> dialogues = new List<Sentences>();

}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite sprite;
    public Lenguages lenguages;
}


[System.Serializable]
public class Lenguages
{
    public string portuguese;
    public string english;
}

