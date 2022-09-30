using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public Guard guard1;
    public Guard guard2;
    public Guard guard3;
    public Guard guard4;
    public Guard guard5;
    public Guard guard6;
    public Guard guard7;
    public Guard guard8;
    public Guard guard9;
    public Guard guard10;
    public Guard guard11;
    public Guard guard12;
    public CatchMeter meter;
    float current, max;

    // Update is called once per frame
    void Update()
    {
        // Really scuffed method to ensure all guards interact with the catch meter
        current = guard1.playerTimer + guard2.playerTimer + guard3.playerTimer + guard4.playerTimer + guard5.playerTimer + guard6.playerTimer + guard7.playerTimer + guard8.playerTimer + guard9.playerTimer + guard10.playerTimer + guard11.playerTimer + guard12.playerTimer;
        max = guard1.timeToSpot;
        meter.UpdateMeter(max, current);
    }
}
