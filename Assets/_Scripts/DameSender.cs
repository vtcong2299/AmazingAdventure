using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : MonoBehaviour
{
    public DameReceiver dameReceiver;
    public float damage = 1f;
    private void Start()
    {
        dameReceiver = GetComponent<DameReceiver>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        ColliderSendDame(collision);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        NotSendDame(collision);
    }
    public virtual void NotSendDame(Collision2D collision)
    {

    }
    public virtual void ColliderSendDame(Collision2D collision)
    {
        if (dameReceiver != null)
        {
            dameReceiver.Receiver(damage);
        }
        else
        {
            return;
        }
    }
}
