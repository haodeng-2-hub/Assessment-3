using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioClip introBgm;
    [SerializeField] AudioClip normalBgm;
    [SerializeField] AudioClip scaredBgm;
    [SerializeField] AudioClip deadBgm;
    [SerializeField] float fallbackSwitchTime = 3f;
    float timer;
    bool switched;

    void OnEnable()
    {
        if (bgmSource == null) bgmSource = GetComponent<AudioSource>();
        switched = false;
        timer = 0f;
        if (introBgm != null)
        {
            bgmSource.clip = introBgm;
            bgmSource.loop = false;
            bgmSource.Play();
        }
        else SwitchToNormal();
    }

    void Update()
    {
        if (switched) return;
        timer += Time.deltaTime;
        if (!bgmSource.isPlaying || timer >= fallbackSwitchTime) SwitchToNormal();
    }

    public void SwitchToNormal()
    {
        switched = true;
        if (normalBgm == null) return;
        bgmSource.clip = normalBgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void SwitchToScared()
    {
        if (scaredBgm == null) return;
        bgmSource.clip = scaredBgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void SwitchToDead()
    {
        if (deadBgm == null) return;
        bgmSource.clip = deadBgm;
        bgmSource.loop = false;
        bgmSource.Play();
    }
}
