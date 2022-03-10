using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimonSaysGame 
{ 

[CreateAssetMenu(fileName = "Custom Game", menuName = "Movement Game/Custom Game", order = 1)]
public class CustomGame : ScriptableObject
{
    [TextArea] public string description;
    public Stage[] Stages; //Each stage is a sequence.

    /// <summary>
    /// Updates the names to the sequence name
    /// </summary>
    private void OnValidate()
    {
        for (int i = 0; i < Stages.Length; i++)
        {
            Stages[i].name = Stages[i].sequence.name;
        }
    }
}

[System.Serializable]
public struct Stage
{
    [HideInInspector] public string name;
    public CustomSequence sequence;
}

}