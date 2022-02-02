using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayPortal : MonoBehaviour
{
    
    [SerializeField] GameObject PortalReceiver;
    [SerializeField] GameObject Player;

    private SpriteRenderer playersprite;

    [Header("Character enters from the left:")]
    [Tooltip("Does the character enter this teleporter from the left side?")]
    public bool facingRight = true;

    private float buff = .6f;
    void Start()
    {
        playersprite= Player.GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!facingRight)
                Player.transform.position =
                    new Vector2(PortalReceiver.transform.position.x - buff, PortalReceiver.transform.position.y);
            else
                Player.transform.position =
                    new Vector2(PortalReceiver.transform.position.x + buff, PortalReceiver.transform.position.y);
        }
    }
}
