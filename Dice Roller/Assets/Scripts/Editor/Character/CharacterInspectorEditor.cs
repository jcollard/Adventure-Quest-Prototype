using UnityEditor;
using AdventureQuest.Character;

namespace AdventureQuest.Editor.Character
{

    [CustomEditor(typeof(CharacterInspector))]
    public class CharacterInspectorEditor : UnityEditor.Editor
    {

        private SerializedProperty _observableCharacter;
        private CharacterInspector _characterInspector;

        void OnEnable()
        {
            _observableCharacter = serializedObject.FindProperty("_observableCharacter");
            _characterInspector = (CharacterInspector)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_observableCharacter);
            if (_characterInspector.Character == null)
            {
                EditorGUILayout.LabelField("Character Data", "Character data not initialized");
            }
            else
            {
                RenderCharacter(_characterInspector.Character);
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void RenderCharacter(ICharacter character)
        {
            EditorGUILayout.LabelField("Name", character.Name);
            character.Gold = EditorGUILayout.IntField("Gold", character.Gold);
            foreach (Ability ability in Abilities.Types)
            {
                EditorGUILayout.LabelField(ability.ToString(), character.Abilities.Score(ability).Score.ToString());
            }
        }

    }

}