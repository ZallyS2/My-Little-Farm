using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip bgmMusic;
    private AudioManeger audioM;

    private void Awake()
    {
        audioM = FindObjectOfType<AudioManeger>();
    }

    void Start()
    {
        audioM.PlayBGM(bgmMusic);
    }

    void Update()
    {
        
    }
}
