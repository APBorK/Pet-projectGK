using System;

public class EventSystem
{
    public static Action<float, float> OnMovePlayer;
    public static Action<bool> OnStopPlayer;
    public static Action<bool> OnPlayerMining;

    public static void SendMovePlayer(float positionX, float positionY)
    {
        if (OnMovePlayer != null)
        {
            OnMovePlayer.Invoke(positionX,positionY);
        }
    }
    
    public static void SendStopPlayer(bool stop)
    {
        if (OnStopPlayer != null)
        {
            OnStopPlayer.Invoke(stop);
        }
    }
    
    public static void SendPlayerMining(bool mining)
    {
        if (OnPlayerMining != null)
        {
            OnPlayerMining.Invoke(mining);
        }
    }
}
