using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> myList = new List<AudioClip>();

    public static void PlayAudio(int audioID, float audioVol)
    {
        GameObject soundHandeler = GameObject.Find("Handeler");

        List<AudioClip> myList = soundHandeler.GetComponent<SoundManager>().myList;
        AudioSource source = soundHandeler.GetComponent<AudioSource>();

        source.PlayOneShot(myList[audioID], audioVol);
    }
}