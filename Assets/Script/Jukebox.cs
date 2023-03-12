using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jukebox : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_Text nameOfTheSong;
    List<AudioClip> audioClipList = new List<AudioClip>();
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addTrack(AudioClip sound)
    {
        List<string> ListToPutOnDropdown = new List<string>();
        ListToPutOnDropdown.Add(sound.name);
        dropdown.options.Add(new TMP_Dropdown.OptionData(sound.name));
        audioClipList.Add(sound);
    }
    public void playTheMusic()
    {
       
        foreach(AudioClip sound in audioClipList)
        {
            if(sound.name == nameOfTheSong.text)
            {
                audioSource.clip = sound;
            }
        }
        audioSource.Play(); 
    }
}
