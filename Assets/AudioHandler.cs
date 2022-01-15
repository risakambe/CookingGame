using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public void PlaySoundeffect(int idx)
    {
        FindObjectOfType<AudioManager>().PlaySoundeffect(idx);
    }
    
}
