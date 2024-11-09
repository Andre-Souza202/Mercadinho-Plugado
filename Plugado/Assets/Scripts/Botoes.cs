using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botoes : MonoBehaviour
{

    public GameObject panelMenu;
    public GameObject panelJogo;
    public GameObject cameraMovement;
    public Vector3 space;


    public void BtnIniciar()
    {
        panelMenu.SetActive(false);
        JogoControlador.Instance.IniciarNovoJogo();
        panelJogo.SetActive(true);
    }

    public void BtnSair()
    {
        Application.Quit();
    }

    public void BtnReiniciar()
    {
        JogoControlador.Instance.IniciarNovoJogo();
    }

    public void BtnMenu()
    {
        panelJogo.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void LadoEsquerdo()
    {
        cameraMovement.transform.position -= space;
        if(cameraMovement.transform.position.x < 0)
        {
            cameraMovement.transform.position = new Vector3(0, 0, -10);
        }
    }

    public void LadoDireito()
    {
        cameraMovement.transform.position += space;
        if (cameraMovement.transform.position.x > 71)
        {
            cameraMovement.transform.position = new Vector3(71, 0, -10);
        }
    }
}
