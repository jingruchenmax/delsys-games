using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    //Used to sort buttons into groups based on what limb is intended to interact with them
    public enum Group {Left_Arm, Right_Arm, Left_Leg, Right_Leg, Upper_Panel};
    //This is an enum of every button type in the game
    public enum ButtonVisual { Round_Red, Round_Green, Stop, Yellow_Rectangle, Power, Lever, Pedal };

    [CreateAssetMenu(fileName = "Custom Sequence", menuName = "Movement Game/Custom Sequence", order = 1)]
    public class CustomSequence : ScriptableObject
    {
        [SerializeField] public string sequenceName = "New Sequence";
        [SerializeField] [TextArea] public string Description = "Its a sequence";
        [SerializeField] public ButtonInfo[] sequence;

        /// <summary>
        /// Updates the Inspector with the name to make things more readable for the clinition
        /// </summary>
        private void OnValidate()
        {
            name = sequenceName;
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i].name = $"{sequence[i].group} {sequence[i].button}";
            }
        }
    }

    [System.Serializable]
    //This is a struct containing info to be displayed in the inspector. The clinition will see and set these values
    //The group and button type are used to identify buttons in game and are atached to each button
    public struct ButtonInfo
    {
        [HideInInspector] public string name;//Used to change the inspector element name to something that makes sense but servers no other purpose 
        public Group group;
        public ButtonVisual button;
        //If there is ever more than one button sharing ths same appearence then this can be used to further locate buttons
        //It is hidden for now as it is not being used
        [HideInInspector] public int buttonNumber; 
    }
}
