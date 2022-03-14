using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    //Used to sort buttons into groups based on what limb is intended to interact with them and or area they belong to
    public enum Group {Left_Arm, Right_Arm, Left_Leg, Right_Leg, Upper_Panel};
    //This is an enum of every button type in the game
    public enum ButtonVisual { Round_Red, Round_Green, Stop, Yellow_Rectangle, Power, Big_Lever, Pedal, Small_Lever};

    /*This class is representing a seires of buttons that the user would press in a stage. 
     * The progression of a stage starts with the first button and then asks the user to reapeat it. 
     * Once repeated then the user will be asked to repeate the first and second button in the
     * sequence. The pattern to reapeat will keep increasing untill the whole sequence of buttons is utilized. 
     * Once all buttons in the sequence have been repeated sucessfully, the stage is complete.
     */
    [CreateAssetMenu(fileName = "Custom Sequence", menuName = "Movement Game/Custom Sequence", order = 1)]
    public class CustomSequence : ScriptableObject
    {
        [SerializeField] private string sequenceName = "New Sequence";
        [SerializeField] public bool isTutorial;
        [SerializeField] [TextArea] private string Description = "Its a sequence";
        [SerializeField] private ButtonInfo[] sequence;

        /// <summary>
        /// Creates a usable sequence for the SimonSays script which is limited by the enabled zones
        /// Buttons being passed should have ID numbers assigned already representing thier position
        /// in the master list of buttons.
        /// </summary>
        public List<int> GenerateSequence(List<InteractionBehavior> possibleButtons, Zone[] validZones)
        {
            List<int> outputSequence = new List<int>();
            foreach (ButtonInfo info in sequence)
            {
                if (validZones[(int)info.group].enabled)
                {
                    foreach (InteractionBehavior button in possibleButtons)
                    {
                        if (info == button.buttonIdentification)
                        {
                            outputSequence.Add(button.buttonId);
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("Custom sequence contains elements that are being excluded by disabled zones");
                }
            }
            return outputSequence;
        }

        public int GetNumberOfRounds()
        {
            return sequence.Length;
        }

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
        //If there is ever more than one button sharing the same appearence then this can be used to further locate buttons
        //It is hidden for now as it is not being used (2/22/2022)
        [HideInInspector] public int buttonNumber;

        #region Overloading
        //Some operator overloading to get them to be easily compared
        public static bool operator ==(ButtonInfo a, ButtonInfo b)
        {
            bool outcome = false;
            if (a.group == b.group && a.button == b.button)
            {
                outcome = true;
            }
            return outcome;
        }
        public static bool operator !=(ButtonInfo a, ButtonInfo b)
        {
            bool outcome = true;
            if (a.group == b.group || a.button == b.button)
            {
                outcome = false;
            }
            return outcome;
        }
        #endregion
    }

    [System.Serializable]
    //Represents a zone for interactables to exist. Allows for disabling and enabling of areas
    public struct Zone
    {
        public string name;
        public bool enabled;
    }
}
