using UnityEngine;


namespace Assets.Script.Store_Data
{
    [CreateAssetMenu(menuName = "Quest", fileName = "NewQuest")]
    public class Quests : ScriptableObject
    {
        public string Title;
        public string Discription;
        public int required;
        public int Exp_reward;
        public RewardType reward;
    }

    public enum RewardType { wood, rock, food }
}

