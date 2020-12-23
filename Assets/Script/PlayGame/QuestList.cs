using Assets.Script.Store_Data;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Script.Play_Game
{
    public class QuestList : MonoBehaviour
    {
        public List<Quests> list_Quest = new List<Quests>();
        public GameObject MissionPrefabs;
        public Transform QuestWindown;

        [SerializeField] private GameObject QuestInformation;
        private bool isOpenQuest;

        [SerializeField] private TextMeshProUGUI Quest_Detile;
        [SerializeField] private List<GameObject> Quest_Enable;

        private Quests current_Quest;

        private void Start()
        {
            QuestInformation.SetActive(false);
        }


        // Kiểm tra một các tuần tự khi chúng ta bấm mở Windown Quest lên 
        // Mục đích ở đây để kiểm tra xem hiện đang có bao nhiêu Quest trong List
        // Và từ đó chúng ta cx sẽ tạo các Prefabs tương ứng với từng ấy phần tử.

        public void Check_Quest()
        {
            Quest_Enable.ForEach((quest) => Destroy(quest));
            Quest_Enable.Clear();
            foreach (var quest in list_Quest)
            {

                // Khởi tạo các Object tại Transform của QuestWindown
                GameObject questclone = Instantiate(MissionPrefabs, QuestWindown);


                questclone.GetComponent<QuestTitle>().questTitle = quest.Title;
                questclone.GetComponent<QuestTitle>().unityEvent.AddListener(() => 
                {
                    TurnOnQuestInformation(quest.Discription, quest.Exp_reward,quest.required, quest); // Thêm Event chuyển text
                });

                // Thêm các Object vào Quest hiển thị
                Quest_Enable.Add(questclone);
            }
        }


        public void TurnOnQuestInformation(string Discription, int Exp_reward, int required,Quests quests)
        {
            current_Quest = quests;
            isOpenQuest = !isOpenQuest;
            QuestInformation.SetActive(isOpenQuest);
            Quest_Detile.text = $"Dcription : {Discription} \nRequired : {required}\nExp_Reward : {Exp_reward}";
        }


        public void Done()
        {
            if(current_Quest.reward == RewardType.wood)
            {
                if (Resousce.Instance.woods >= current_Quest.required)
                {
                    Resousce.Instance.woods += current_Quest.Exp_reward;

                    // Sau khi thực hiện xong nhiệm vụ đó thì xóa nó ra khỏi danh sách hiển thị.
                    Quest_Enable.ForEach((button) =>
                       {
                           if (current_Quest.Title.Equals(button.GetComponent<QuestTitle>().questTitle))
                           {
                               Destroy(button);
                           }
                       }
                    );

                    // Sau khi xóa nó ra khỏi danh sách hiện thị thì tương tự với việc xóa dữ liệu ngầm của nó
                    // Ở đây ta xóa các Button của Quest mà khi làm xong rồi thì cả Button Quest và Cả Data Quest cũng phải xóa vậy nên
                    // Có nghĩa là Data Quest phải xóa ở đây là các phần tử trong list_Quest đã tạo ở trên

                    if (list_Quest.Contains(current_Quest))
                    {
                        list_Quest.Remove(current_Quest);
                    }
                }
            }
            else if (current_Quest.reward == RewardType.rock)
            {
                if (Resousce.Instance.rocks >= current_Quest.required)
                {
                    Resousce.Instance.rocks += current_Quest.Exp_reward;

                    // Sau khi thực hiện xong nhiệm vụ đó thì xóa nó ra khỏi danh sách hiển thị
                    Quest_Enable.ForEach((button) =>
                    {
                        if (current_Quest.Title.Equals(button.GetComponent<QuestTitle>().questTitle))
                        {
                            Destroy(button);
                        }
                    }
                    );

                    // Sau khi thực hiện xong nhiệm vụ đó thì xóa nó ra khỏi danh sách hiển thị
                    // Sau khi xóa nó ra khỏi danh sách hiện thị thì tương tự với việc xóa dữ liệu ngầm của nó
                    // Ở đây ta xóa các Button của Quest mà khi làm xong rồi thì cả Button Quest và Cả Data Quest cũng phải xóa vậy nên
                    // Có nghĩa là Data Quest phải xóa ở đây là các phần tử trong list_Quest đã tạo ở trên

                    if (list_Quest.Contains(current_Quest))
                    {
                        list_Quest.Remove(current_Quest);
                    }
                }
            }
            else if (current_Quest.reward == RewardType.food)
            {
                if (Resousce.Instance.foods >= current_Quest.required)
                {
                    Resousce.Instance.foods += current_Quest.Exp_reward;
                    // Sau khi thực hiện xong nhiệm vụ đó thì xóa nó ra khỏi danh sách hiển thị

                    Quest_Enable.ForEach((button) =>
                    {
                        if (current_Quest.Title.Equals(button.GetComponent<QuestTitle>().questTitle))
                        {
                            Destroy(button);
                        }
                    }
                    );

                    // Sau khi thực hiện xong nhiệm vụ đó thì xóa nó ra khỏi danh sách hiển thị
                    // Sau khi xóa nó ra khỏi danh sách hiện thị thì tương tự với việc xóa dữ liệu ngầm của nó
                    // Ở đây ta xóa các Button của Quest mà khi làm xong rồi thì cả Button Quest và Cả Data Quest cũng phải xóa vậy nên
                    // Có nghĩa là Data Quest phải xóa ở đây là các phần tử trong list_Quest đã tạo ở trên


                    if (list_Quest.Contains(current_Quest))
                    {
                        list_Quest.Remove(current_Quest);
                    }
                }
            }
            isOpenQuest = !isOpenQuest;
            QuestInformation.SetActive(isOpenQuest);
        }
    }
}