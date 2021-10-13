using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSentences{

    public string objectName;

    [TextArea(3,6)]
    public string[] sentences;

}
