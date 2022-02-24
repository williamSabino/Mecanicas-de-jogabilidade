using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    //Componentes e objects
    private Rigidbody playerRb;
    private GameObject FocoCamera;
    public GameObject powerupIndicador;

    //Primitivas
    private float speed = 5.0f;
    private float strongForce = 10;

    //Booleanas
    public bool hasPowerup = false;

    // metodo de inicio de game executado apenas uma vez 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        FocoCamera = GameObject.Find("Foco camera");
    }

    //metodo central update
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(FocoCamera.transform.forward * speed * fowardInput);

        powerupIndicador.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    //detector de colisão para o powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicador.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCount());
        }
    }

    //contagem de segundos para finalizar o powerup
    IEnumerator PowerUpCount()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicador.gameObject.SetActive(false);
    }


    //detector de colisão para os enemigos caso esteja com powerup ativado
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //adicionando rigidbody ao inimigo colidido
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //atribuindo o tipo de força que sera exercida apos colisão
            Vector3 backPosition = (collision.gameObject.transform.position - transform.position);

            //aplicando a força
            enemyRigidbody.AddForce(backPosition * strongForce, ForceMode.Impulse);
            Debug.Log("O player colidiu com :" + collision.gameObject.name + "Quando o power up estava" + hasPowerup);
        }
    }
}
