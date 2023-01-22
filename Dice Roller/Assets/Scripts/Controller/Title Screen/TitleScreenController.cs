using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Scene;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{

    [SerializeField]
    private Button _continueButton;

    public void CreateNewCharacter()
    {
        Location.CharacterCreator.Transition(PlayerCharacter.NewCharacter);
    }

    public void ContinueAdventure()
    {
        Location.Town.Transition(PlayerCharacter.Restore());        
    }

    protected void Awake()
    {
        _continueButton.interactable = PlayerPrefs.HasKey("character");
    }

}
