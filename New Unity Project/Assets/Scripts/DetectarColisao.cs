using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisao : MonoBehaviour
{
    [Tooltip("Tempo para permanecer antes de se mover")]
    public float defaultStayTime = .5f;
    [Tooltip("Objetos que serão movimentados")]
    public LevantarColisores[] levantarColisores;

    private void Start()
    {
        for(int i = 0; i < levantarColisores.Length; i++)
        {
            levantarColisores[i].defaultStayTime = defaultStayTime;
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != transform && other.transform.CompareTag("Player") && other.GetComponent<Invector.vCharacterController.vCharacter>() != null)
        {
            other.transform.parent = transform;
            for(int i = 0; i < levantarColisores.Length; i++)
            {
                levantarColisores[i].Inverter(true);
            }
        }
    }
}
