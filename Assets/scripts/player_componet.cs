using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pllayer_componet : MonoBehaviour
{
    //silnik fizyczny dla obiektu gracza
    Rigidbody rb;
    //si�a skoku
    public float jumpForce = 5f;

    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //przypnij rigidbody gracza do zmiennej rb
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //idzie w prawe sam
        //transform.position += new Vector3(1, 0, 3) * Time.deltaTime;
        //zczytuje klawe
        float x = Input.GetAxisRaw("Horizontal");

        //wysiwetluje stan klawy
        //Debug.Log(x);

        //wylicz przesuniecie w osi x
        Vector3 movment = Vector3.right * x;

        //wylicz przesuniecie w osi y i dodaj istniejacego przesuniecia w osi x
        float y = Input.GetAxisRaw("Vertical");

        //wylicz przesuniecie w osi y i dodaj d istniejacego przesuniecia w osi x
        movment += Vector3.forward * y;

        //normalizujemy wektor
        movment = movment.normalized;

        //poprawka na czas od ostaniej klatki
        movment *= Time.deltaTime;

        //pomn� przez pr�dko�� ruchu
        movment *= moveSpeed;

        //przesun gracza w osi x
        //transform.position += movment;

        //pr�bujemy u�yc translate zamiast dodawac wsp�rz�dne
        transform.Translate(movment);

    }
    //proba obejscia problemu z op�nieniem wej�cia poprzez przeniesienie go do update

    private void Update()
    {
        //sprawdz czy nacisnieto spacj� (skok)
        //zwraca true je�li zacz�li�my naciska� spacj� w trakcie klatki animacji
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        //sprawdz czy znajduje si� na poziomie 0
        if (transform.position.y <= Mathf.Epsilon)
        {
        //dodaj si�� skoku
         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)

    {
        //funkcja wykrwyje kazdy collider ktory jest trigerem
        //(moze byc wszystko typu kamera albo box)

        if (other.CompareTag("LevelEnd"))
        {
            //stanelismy w miejscu gdzie sie wygrywa
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnWin();
        }

        if (other.CompareTag("CameraView"))
        {
            //zobaczy�a nas kamera - przegrana
            GameObject.Find("LevelManager").GetComponent<LevelManager>().OnLose();

        }

    }
}
