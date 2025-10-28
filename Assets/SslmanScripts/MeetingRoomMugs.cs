using UnityEngine;

public class MeetingRoomMugs : MonoBehaviour
{






    public void PlayerTakeTheMug()
    {

TransitionMNGscripts.Instance.TakeMug();
        Destroy(gameObject);

    }
}
