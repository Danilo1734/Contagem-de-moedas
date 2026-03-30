using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        ScoreTextScript.coinAmount += 1;
        Destroy (gameObject);
    }
}
