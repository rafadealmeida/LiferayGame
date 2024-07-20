using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{
    [TextArea(1, 4)]
    public string[] locutores;
    [TextArea(1, 4)]
    public string[] sentencas;
}
