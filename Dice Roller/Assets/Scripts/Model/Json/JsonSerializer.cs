using UnityEngine;

namespace AdventureQuest.Json
{
    public class JsonSerializer
    {
        
        [field: SerializeField]
        public string Json { get; private set; }
        [field: SerializeField]
        public string ClassInformation { get; private set; }
        public System.Type ClassType => System.Type.GetType(ClassInformation);

        public static string ToJson(IJsonable jsonable)
        {
            JsonSerializer serializer = new ();
            serializer.Json = jsonable.AsJson;
            serializer.ClassInformation = jsonable.GetType().FullName;
            return JsonUtility.ToJson(serializer);
        }

    }
}