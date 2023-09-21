using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Channel<T> where T : Signal
{
    public delegate void SignalEventHandler(T sig);

    public static event SignalEventHandler SignalReceived;

    public static void Subscribe(SignalEventHandler handler)
    {
        SignalReceived += handler;
    }

    public static void RaiseEvt(T sig)
    {
        SignalReceived.Invoke(sig);
    }

}
