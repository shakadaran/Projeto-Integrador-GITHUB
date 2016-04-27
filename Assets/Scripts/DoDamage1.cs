using UnityEngine;
using System.Collections;

public class DoDamage1 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterClass>())
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<CharacterClass>().checkToApplyDamage();
            }
        }
    }
}
