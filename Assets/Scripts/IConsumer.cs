
using UnityEngine;

/// <summary>
/// IConsumer is able to consume items passed to it.
/// </summary>
public interface IConsumer
{
    bool Give(GameObject obj);
}