using NUnit.Framework;
using System.Collections.Generic;
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
