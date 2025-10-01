using UnityEngine;
using TMPro;

public class NPCCommandHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject npc;
    public TextMeshProUGUI npcText;

    public AudioSource audioSource;

    public AudioClip helloClip;
    public AudioClip goodClip;
    public AudioClip nameClip;
    public AudioClip unknownClip;

    void Start()
    {
        inputField.onSubmit.AddListener(HandleCommand);
    }

    void HandleCommand(string command)
    {
        command = command.Trim().ToLower();  // Normalize input

        if (command == "hello")
        {
            Debug.Log("how are you?");
            npcText.text = "NPC: how are you?";

            PlayAudio(helloClip);
        }
        else if (command == "good")
        {
            Debug.Log("that's perfect");
            npcText.text = "NPC: that's perfect";

            PlayAudio(goodClip);
        }
        else if (command == "name?")
        {
            Debug.Log("my name is NPC");
            npcText.text = "NPC: my name is NPC";

            PlayAudio(nameClip);
        }
        else
        {
            Debug.Log("I don't understand. Please say again.");
            npcText.text = "NPC: I don't understand. Please say again.";

            PlayAudio(unknownClip);
        }

        inputField.text = "";  // Clear input
        inputField.ActivateInputField();  // Focus again
    }

    void PlayAudio(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

}
