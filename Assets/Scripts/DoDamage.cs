using UnityEngine;
using System.Collections;

public class DoDamage : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterClass>())
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<CharacterClass>().checkToApplyDamage();
            }
        }
    }
}
