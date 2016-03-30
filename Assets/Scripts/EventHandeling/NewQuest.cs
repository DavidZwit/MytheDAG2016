using UnityEngine;
using System.Collections;

public class NewQuest : MonoBehaviour
{
    private int objectivesLeft;
    private RandomQuest randomQuest;

    void Awake()
    {
        randomQuest = GameObject.Find("Handeler").GetComponent<RandomQuest>();
    }

    void ObjectiveStatus()
    {
        objectivesLeft--;
        if (objectivesLeft <= 0)
        {
            EndQuest();
            print("Quest Won!");
        }
    }

    void DestroyedGameObject(GameObject obj)
    {
        ObjectiveStatus();
    }

    IEnumerator Counter(int time)
    {
        while (time >= 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        EndQuest();
    }

    void EndQuest()
    {
        print("Quest Lost!");
        randomQuest._haveQuest = false;
        EventHandeler._buildingBroke -= DestroyedGameObject;
    }

    public void QuestKillEnemy(int timeLeft)
    {
        StartCoroutine(Counter(timeLeft));
    }

    public void QuestDestroyBuilding(int timeLeft)
    {
        StartCoroutine(Counter(timeLeft));
        objectivesLeft = 5;
        EventHandeler._buildingBroke += DestroyedGameObject;
    }
}
