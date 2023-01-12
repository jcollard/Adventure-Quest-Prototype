using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AdventureQuest.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class StatusScreenController : MonoBehaviour
    {
        public void CloseStatusScreen()
        {
            gameObject.GetComponent<CharacterController>().StoreCharacter();
            SceneManager.LoadScene("Town");
        }
    }
}