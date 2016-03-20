using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestDisplayer : MonoBehaviour
{
    private GameObject curQuest;
    private NewQuest newQuest;
    [SerializeField] private List<GameObject> questNames = new List<GameObject>();
    /*
        QuestList:
        [0] = Kill 5 Enemies
        [1] = Destroy 5 Buildings
        [2] = ...
    */

    void Awake()
    {
        newQuest = GameObject.Find("Handeler").GetComponent<NewQuest>();
    }

    public void SpawnQuestText(int i)
    {
        curQuest = Instantiate(questNames[i]) as GameObject;
        curQuest.transform.parent = transform;
        curQuest.transform.position += new Vector3(253, 150, 0);
    }
}
