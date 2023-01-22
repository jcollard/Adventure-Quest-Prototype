using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Scene;


namespace AdventureQuest.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class StatusScreenController : MonoBehaviour
    {
        public void CloseStatusScreen()
        {
            // TODO: Return to the screen prior to this one rather than the town scene.
            PlayerCharacter character = (PlayerCharacter)gameObject.GetComponent<CharacterController>().PlayerCharacter;
            Location.Town.Transition(character);
        }
    }
}