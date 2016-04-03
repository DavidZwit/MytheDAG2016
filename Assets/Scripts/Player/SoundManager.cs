using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour
{
    public List<AudioClip> myList = new List<AudioClip>();
    public bool[] soundsPlaying;
    public delegate void DonePlaying();
    void Start()
    {
        soundsPlaying = new bool[myList.Count];
    }
    public static void PlayAudio(int audioID, float audioVol, DonePlaying returnDelegate = null)
    {
        GameObject soundHandeler = GameObject.Find("Handeler");
        SoundManager manager = soundHandeler.GetComponent<SoundManager>();
        if (!manager.soundsPlaying[audioID])
        {
            List<AudioClip> myList = soundHandeler.GetComponent<SoundManager>().myList;
            AudioSource source = soundHandeler.GetComponent<AudioSource>();
            manager.StartCoroutine(manager.SoundDonePlaying(returnDelegate, audioID, myList[audioID].length));
            manager.soundsPlaying[audioID] = true;
            source.PlayOneShot(myList[audioID], audioVol);
        }
    }
    public IEnumerator SoundDonePlaying(DonePlaying returnDelegate, int audioID, float waitTime)
    {
        bool firstTimePlaying = true;
        if (firstTimePlaying)
        {
            yield return new WaitForSeconds(waitTime);
            firstTimePlaying = false;
        }
        else {
            soundsPlaying[audioID] = false;
            if (returnDelegate != null) returnDelegate();
            yield return null;
        }
    }
}