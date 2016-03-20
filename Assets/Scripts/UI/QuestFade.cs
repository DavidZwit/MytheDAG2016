using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestFade : MonoBehaviour
{
    private Color color;
    private float velocity = 0;

    void Awake()
    {
        color = GetComponent<Text>().color;
    }
    
	void Start ()
    {
        color.a = 0;
        FadeIn();
	}

    private void FadeIn()
    {
      //  float fade = Mathf.SmoothDamp(1, 0, ref velocity, 0.25f);
     //   color.a = 0.1f;
    }

}
