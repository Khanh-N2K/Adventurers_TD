using UnityEngine;

public class AnimationStatus : MonoBehaviour 
{
    public void SwitchAnim(Status status)
    {
        switch(status)
        {
            case Status.Idle:
                break;
            case Status.Attack:
                break;
            case Status.Move:
                break;
        }
    }
}