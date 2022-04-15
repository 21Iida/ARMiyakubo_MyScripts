using UnityEngine;

namespace Iida
{
    public class AnnouncePlay : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        public void PlayAudio(AudioClip announceClip)
        {
            audioSource.clip = announceClip;
            audioSource.Play();
        }
    }
}
