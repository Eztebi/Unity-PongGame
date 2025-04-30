using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    [SerializeField]List<GameObject> listPuntos = new List<GameObject>();

    public List<GameObject> puntaje1Player1List = new List<GameObject>();
    public List<GameObject> puntaje2PLayer1List = new List<GameObject>();

    private int puntaje1Player1=0;
    private int puntaje2Player1=0;
    private int puntaje1Player2=0;
    private int puntaje2Player2=0;
    public List<GameObject> puntaje1Player2List = new List<GameObject>();
    public List<GameObject> puntaje2PLayer2List = new List<GameObject>();
    public Transform posPuntaje1Player1;
    public Transform posPuntaje2Player1;
    public Transform posPuntaje1Player2;
    public Transform posPuntaje2Player2;
    // Start is called before the first frame update
    void Start()
    { 
        puntaje1Player1 = 0;
  puntaje2Player1 = 0;
 puntaje1Player2 = 0;
  puntaje2Player2 = 0;
    puntaje1Player1List.Clear();
        puntaje2PLayer2List.Clear();
        puntaje1Player2List.Clear();
        puntaje2PLayer2List.Clear();

        puntaje1Player1List.Add(listPuntos[puntaje1Player1]);
        puntaje2PLayer2List.Add(listPuntos[puntaje1Player1]);
        puntaje1Player2List.Add(listPuntos[puntaje1Player1]);
        puntaje2PLayer2List.Add(listPuntos[puntaje1Player1]);
    }

   public void ActualizarPuntaje1()
    {
        if (GameManager.instance.Score1 == false) { }
        else if(puntaje1Player1 ==0 && puntaje1Player2==0)
        {
            puntaje1Player1++;
            puntaje1Player1List.Clear();
            puntaje1Player1List.Add(listPuntos[puntaje1Player1]);
        }
        else if(puntaje1Player1==9)
        {
            puntaje1Player1=0;
            puntaje2Player1++;
            puntaje1Player1List.Clear();
            puntaje2PLayer1List.Clear();
            puntaje1Player1List.Add(listPuntos[puntaje1Player1]);
            puntaje2PLayer1List.Add(listPuntos[puntaje1Player1]);
        }
    }
    public void ActualizarPuntaje2()
    {
        if(GameManager.instance.Score2 == false) { }
    }
}
