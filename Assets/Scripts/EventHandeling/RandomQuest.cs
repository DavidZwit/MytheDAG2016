using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomQuest : MonoBehaviour
{
    private List<string> availableQuest;
    private NewQuest newQuest;
    private QuestDisplayer questDisplayer;
    private bool haveQuest;
    public bool _haveQuest
    {
        get { return haveQuest; }
        set { haveQuest = value; }
    }
    private int questChance;
    private string randomQuest;

    void Awake()
    {
        newQuest = GameObject.Find("Handeler").GetComponent<NewQuest>();
        questDisplayer = GameObject.Find("QuestDisplay").GetComponent<QuestDisplayer>();
    }

    void Start()
    {
        availableQuest = new List<string>();
        availableQuest.Add("Kill 5 enemies!");
        availableQuest.Add("Destroy 5 buildings!");
    }

    void FixedUpdate()
    {
        //If there isn't a quest running; start a chance for a new quest
        if (!haveQuest)
            GetQuest();
    }
    
    private void GetQuest()
    {
        questChance++;
        if (questChance % 4 == 0)
        {
            int i = Random.Range(0, 20);

            if (i == 0)
            {
                print("New Quest");
                SetQuest();
                haveQuest = true;
            }
        }
    }

    private void SetQuest()
    {
        randomQuest = availableQuest[Random.Range(0, availableQuest.Count)];
        print(randomQuest);

        switch(randomQuest)
        {
            case "Kill 5 enemies!":
                newQuest.QuestKillEnemy(3);
                questDisplayer.SpawnQuestText(0);
                break;
            case "Destroy 5 buildings!":
                newQuest.QuestDestroyBuilding(3);
                questDisplayer.SpawnQuestText(1);
                break;
        }
    }
}