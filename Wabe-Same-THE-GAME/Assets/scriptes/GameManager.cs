using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public float velocidad = 2;
    public GameObject col;
    public GameObject col2;
    public GameObject piedra1;
    public GameObject piedra2;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;
    public List<GameObject> cols;
    public List<GameObject> cols2;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        // Crear Mapa
        for (int i=0; i<21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i,-3), Quaternion.identity));
        }
        //Crear techo invicible
        for (int i=0; i<21; i++)
        {
            cols2.Add(Instantiate(col2, new Vector2(-10 + i, 0), Quaternion.identity));
        }
        //Crear piedras
        obstaculos.Add(Instantiate(piedra1, new Vector2(-14,-2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(18,-2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f,0) * Time.deltaTime;

        // Mover Mapa
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position= new Vector3(10, -3, 0);
            }
            cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        //Mover Obstaculos
        for (int i = 0; i < obstaculos.Count; i++)
        {
            if (obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(11, 18);
                obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
            }
            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        //Mover Techo
        for (int i = 0; i < cols2.Count; i++)
        {
            if (cols2[i].transform.position.x <= -10)
            {
                cols2[i].transform.position = new Vector3(10, 0, 0);
            }
            cols2[i].transform.position = cols2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }
        }
    }
}