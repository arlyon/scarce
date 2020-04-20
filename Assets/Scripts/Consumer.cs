using System;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    public IConsumer consumer;

    private void OnTriggerEnter(Collider other)
    {
        consumer.Give(other.gameObject);
    }
}