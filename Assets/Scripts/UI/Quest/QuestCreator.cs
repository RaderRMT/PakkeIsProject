using System;
using Character;
using Json;
using UnityEngine;

namespace UI.Quest
{
    public class QuestCreator : MonoBehaviour
    {
        public QuestData QuestCreatorData;

        public void SetQuest(bool isDone)
        {
            JsonFilesManagerSingleton.Instance.QuestJsonFileManagerProperty.SetQuestCollected(this, isDone);
        }

        private void LaunchAction(Action action)
        {
            action.Invoke();
        }
    }
}