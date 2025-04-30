using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField] Transform respawnIzquierda;
    [SerializeField] Transform respawnDerecha;
   [SerializeField] private Rigidbody2D pelotaRb;
    [SerializeField]private float yforce = 55;
    private float yForce4 =80;
    private float yForce3 = 60;
    private float yForce2 = 40;
    private float yForce1 =20;
    
    [SerializeField]private float xforce = 55;
    private float spawnforce = 55;
    private string spawn;
    Event pelotaScore;
    public puntaje pun1;
    private void Start()
    {
        pelotaRb=GetComponent<Rigidbody2D>();   
        Vector2 initialVelocity = new Vector2(pelotaRb.velocity.x+xforce, pelotaRb.velocity.y+yforce);
        pelotaRb.AddForce(initialVelocity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 nextCollision=Vector2.zero;
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 pDDLEpOS = collision.gameObject.transform.position;
            Vector2 res0=contactPoint- pDDLEpOS;
            Debug.Log(res0.y);
            //Division entre 8 partes del player
            switch (res0.y)
            {
                case > 0.2524267f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce+2, pelotaRb.velocity.y +yForce4);
                    break;
                case > 0.189320025f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce+2, pelotaRb.velocity.y+ yForce3);
                    break;
                case > 0.12621335f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y+yForce2);
                    break;
                case > 0.063106675f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y+ yForce1);
                    break;
                case > -0.063106675f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y+ - yForce1);
                    break;
                case > -0.12621335f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y - yForce2);
                    break;
                case > -0.189320025f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y - yForce3);
                    break;
                case > -0.2524267f:
                    nextCollision = new Vector2(pelotaRb.velocity.x + xforce + 2, pelotaRb.velocity.y - yForce4);
                    break;
                
            }
        }
        switch (collision.gameObject.tag)
        {
            case "ParedArriba":
                nextCollision = new Vector2(pelotaRb.velocity.x+2, pelotaRb.velocity.y - yforce);
              
                break;
            case "ParedAbajo":
                nextCollision = new Vector2(pelotaRb.velocity.x+2, pelotaRb.velocity.y + yforce);
               
                break;
            case "AI":
                nextCollision = new Vector2(pelotaRb.velocity.x - xforce-2, pelotaRb.velocity.y);
               
                break;
           
        }
        pelotaRb.AddForce(nextCollision);
        xforce += 10;
        //yforce += 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        float rndm;
        Vector2 collisionScore = Vector2.zero;
        switch (collision.gameObject.tag)
        {
            case "ParedIzquierda":
                rndm=Random.Range(-3.9f, 4.2f);
                gameObject.transform.position = new Vector2(respawnIzquierda.position.x,rndm);
                pelotaRb.velocity=(Vector2.zero);
                spawn = "izquierda";
                gameObject.SetActive(false);
                Invoke("Spawn",1);
                pun1.ActualizarPuntaje1();
                break;
            case "ParedDerecha":
                rndm = Random.Range(-3.9f, 4.2f);
                gameObject.transform.position = new Vector2(respawnDerecha.position.x, rndm);
                pelotaRb.velocity = (Vector2.zero);
                spawn = "derecha";
                gameObject.SetActive(false);
                Invoke("Spawn", 1);
                pun1.ActualizarPuntaje1();
                break;
        }
    }
    public void Score(Event score) 
    {
        if(score == null) return;
    }
    void Spawn()
    {
        gameObject.SetActive(true);
        xforce = spawnforce;
        float rnd = Random.Range(0, 2);
        if(spawn== "izquierda")
        {
            if (rnd == 0)
            {
                Vector2 initialVelocity = new Vector2(pelotaRb.velocity.x - spawnforce, pelotaRb.velocity.y + spawnforce);
                pelotaRb.AddForce(initialVelocity);
            }
            else
            {

                Vector2 initialVelocity = new Vector2(pelotaRb.velocity.x - spawnforce, pelotaRb.velocity.y - spawnforce);
                pelotaRb.AddForce(initialVelocity);
            }
        }
        else if(spawn=="derecha")
        {
            if (rnd == 0)
            {
                Vector2 initialVelocity = new Vector2(pelotaRb.velocity.x + spawnforce, pelotaRb.velocity.y + spawnforce);
                pelotaRb.AddForce(initialVelocity);
            }
            else
            {

                Vector2 initialVelocity = new Vector2(pelotaRb.velocity.x + spawnforce, pelotaRb.velocity.y - spawnforce);
                pelotaRb.AddForce(initialVelocity);
            }
            
        }
    }
    public void PlayerCollision()
    {

    }
}
