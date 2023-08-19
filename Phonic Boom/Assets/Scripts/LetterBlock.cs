using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LetterBlock : MonoBehaviour
{
    [Header("Scriptable Obj and Text Mesh")]
    [SerializeField] private scriptable_letter scriptableObj;
    [SerializeField] private TextMeshPro blockLetter;

    [Header("Audio")]
    [SerializeField] private float audioDelay = 1.0f;

    private Animator anim;
    private AudioSource audioSource;

    private void Start()
    {
        blockLetter.text = scriptableObj.letter;
        anim = GetComponent<Animator>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            anim.SetTrigger("PlayerCollision");
            audioSource.PlayOneShot(scriptableObj.letterName);
            Invoke("PlaySecondClip", audioDelay);
        }
    }

    private void PlaySecondClip()
    {
        audioSource.PlayOneShot(scriptableObj.phonogram);
        Destroy(gameObject);
    }
}
