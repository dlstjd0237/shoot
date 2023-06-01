using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OnItem : short
{
    powerUp = 0
}

public class Item : MonoBehaviour
{
    [SerializeField]
    OnItem onItem;
    private void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * 1;
        if (transform.position.y <= -7) gameObject.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (onItem)
            {
                case OnItem.powerUp:
                    Player_Attack player_Atk = FindAnyObjectByType<Player_Attack>();
                    if (player_Atk._attackLvel >= 4)
                    {
                        player_Atk._attackLvelTime = 0;
                    }
                    else
                    {
                        player_Atk._attackLvelTime = 0;
                        player_Atk._attackLvel++;

                    }
                    break;
            }
            gameObject.SetActive(false);

        }
    }



}
