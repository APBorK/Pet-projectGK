using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animation;
    void Start()
    {
        _animation = GetComponent<Animator>();
        EventSystem.OnStopPlayer += StartAnimatinWalk;
        EventSystem.OnPlayerMining += StartAnimatinMining;
    }

    private void StartAnimatinWalk(bool stop)
    {
        _animation.SetBool("Move",!stop);
    } 
    
    private void StartAnimatinMining(bool mining)
    {
        _animation.SetBool("Mining",mining);
    } 
}
