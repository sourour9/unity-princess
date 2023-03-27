using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public enum Faces
    {
        Neutral,
        smile,
        fun,

    }
    public string name;
    [TextArea(3, 10)]
    public List<string> sentences;
    public List<Faces> faces;
}
