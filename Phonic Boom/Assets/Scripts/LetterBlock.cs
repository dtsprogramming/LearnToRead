using TMPro;
using UnityEngine;

[RequireComponent(typeof(scriptable_letter), typeof(Animator))]
public class LetterBlock : MonoBehaviour
{
    [SerializeField] private scriptable_letter scriptableObj;
    [SerializeField] private AudioListener camAudio;
    [SerializeField] private float audioDelay = 1.0f;
    [SerializeField] private TextMeshPro blockLetter;

    private Animator anim;

    private void Start()
    {
        blockLetter.text = scriptableObj.letter;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            anim.SetTrigger("PlayerCollision");
            AudioSource.PlayClipAtPoint(scriptableObj.letterName, camAudio.transform.position);
            Invoke("PlaySecondClip", audioDelay);
        }
    }

    private void PlaySecondClip()
    {
        AudioSource.PlayClipAtPoint(scriptableObj.phonogram, camAudio.transform.position);
        Destroy(gameObject);
    }
}
