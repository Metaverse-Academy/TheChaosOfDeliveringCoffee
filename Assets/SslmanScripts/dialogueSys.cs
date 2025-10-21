using UnityEngine;

public class dialogueSys : MonoBehaviour
{
    [SerializeField] private GameObject canvasOfTheDialogueSys;

    public bool IsDialogueAppear = false;

    public void AppearTheDialogue()
    {
        canvasOfTheDialogueSys.SetActive(true);
        IsDialogueAppear = true;
    }
public void DisappearTheDialogue()
    {
        canvasOfTheDialogueSys.SetActive(false);
        IsDialogueAppear = false;
}
}
