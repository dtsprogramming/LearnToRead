using UnityEngine;

[CreateAssetMenu(fileName = "Letter", menuName = "Letter")]
public class scriptable_letter : ScriptableObject
{
    [Header("Letter Values")]
    public string letter = "X";
    public AudioClip letterName;

    [Header("Phonograms")]
    public AudioClip phonogram;

}
