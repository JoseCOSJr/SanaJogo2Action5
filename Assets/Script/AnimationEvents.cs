using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private playerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponentInParent<playerMove>();
    }

    public void ShootNow()
    {
        playerMove.ToShooting();
    }
}
