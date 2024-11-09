using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JogoControlador : MonoBehaviour
{
    public static JogoControlador Instance;

    //Variavel controlada pelo jogador
    public int vMaca;
    public int vLaranja;
    public int vAbacaxi;
    public int vBanana;

    //Resposta
    private int rMaca;
    private int rLaranja;
    private int rAbacaxi;
    private int rBanana;

    //1 = Maça, 2 = Laranja, 3 = Abacaxi, 4 = Banana

    private int personagem;
    private int pedidoPersonagem;
    private bool pediuSim;

    public GameObject panelFim;

    [Header("Imagens")]
    public Image[] imgFrutasDePersonagens;
    public Sprite frutaMaca;
    public Sprite frutaLaranja;
    public Sprite frutaAbacaxi;
    public Sprite frutaBanana;

    [Header("Textos")]
    public TextMeshProUGUI txtMaca;
    public TextMeshProUGUI txtLaranja;
    public TextMeshProUGUI txtAbacaxi;
    public TextMeshProUGUI txtBanana;
    public TextMeshProUGUI txtFim;


    void Awake()
    {
        Instance = this;
    }

    public void IniciarNovoJogo()
    {
        Reiniciar();

        for(int i = 0; i < imgFrutasDePersonagens.Length; i++)
        {
            string _fruta;

            if (pedidoPersonagem == 0)
            {
                _fruta = FrutaAleatoria(true);
            }
            else
            {
                _fruta = FrutaAleatoria(false);
            }

            pedidoPersonagem++;

            if (personagem == 3)
            {
                if(pedidoPersonagem == 0)
                {
                    ProcessarFruta(_fruta, i, false);
                }
                else
                {
                    ProcessarFruta(_fruta, i, true);
                }

                if(pedidoPersonagem == 6)
                {
                    personagem++;
                    pedidoPersonagem = 0;
                }
            }
            else
            {
                ProcessarFruta(_fruta, i, true);

                if (pedidoPersonagem == 3)
                {
                    personagem++;
                    pedidoPersonagem = 0;
                }
            }
        }
    }

    public void Reiniciar()
    {
        vMaca = 0;
        vLaranja = 0;
        vAbacaxi = 0;
        vBanana = 0;

        rMaca = 0;
        rLaranja = 0;
        rAbacaxi = 0;
        rBanana = 0;

        personagem = 0;
        pedidoPersonagem = 0;
        pediuSim = false;
    }

    public string FrutaAleatoria(bool primeira)
    {
        int _rand;

        if (primeira)
        {
            _rand = Random.Range(0, 4);
        }
        else
        {
            _rand = Random.Range(0, 7);
        }

        switch(_rand)
        {
            case 0:
                return "Maca";

            case 1:
                return "Laranja";

            case 2:
                return "Abacaxi";

            case 3:
                return "Banana";

            default:
                return "Nada";
        }
    }

    public void ProcessarFruta(string fruta, int posicao, bool contarResposta)
    {
        switch(fruta)
        {
            case "Maca":
                imgFrutasDePersonagens[posicao].enabled = true;
                imgFrutasDePersonagens[posicao].sprite = frutaMaca;
                if(contarResposta)
                {
                    rMaca++;
                }
                break;

            case "Laranja":
                imgFrutasDePersonagens[posicao].enabled = true;
                imgFrutasDePersonagens[posicao].sprite = frutaLaranja;
                if (contarResposta)
                {
                    rLaranja++;
                }
                break;

            case "Abacaxi":
                imgFrutasDePersonagens[posicao].enabled = true;
                imgFrutasDePersonagens[posicao].sprite = frutaAbacaxi;
                if (contarResposta)
                {
                    rAbacaxi++;
                }
                break;

            case "Banana":
                imgFrutasDePersonagens[posicao].enabled = true;
                imgFrutasDePersonagens[posicao].sprite = frutaBanana;
                if (contarResposta)
                {
                    rBanana++;
                }
                break;

            case "Nada":
                imgFrutasDePersonagens[posicao].enabled = false;
                break;
        }
    }

    public void ChecarVitoria()
    {
        if(vMaca == rMaca && vLaranja == rLaranja && vAbacaxi == rAbacaxi && vBanana == rBanana)
        {
            //Vitoria
            txtFim.text = "Você conseguiu!";
        }
        else
        {
            //Errou
            txtFim.text = "Você não conseguiu comprar o que todos pedira :(";
        }

        panelFim.SetActive(true);
    }

    public void BtnMais(int fruta)
    {
        switch(fruta)
        {
            case 1:
                vMaca++;
                txtMaca.text = vMaca.ToString();
                break;

            case 2:
                vLaranja++;
                txtLaranja.text = vLaranja.ToString();
                break;

            case 3:
                vAbacaxi++;
                txtAbacaxi.text = vAbacaxi.ToString();
                break;

            case 4:
                vBanana++;
                txtBanana.text = vBanana.ToString();
                break;
        }
    }

    public void BtnMenos(int fruta)
    {
        switch (fruta)
        {
            case 1:
                vMaca--;
                txtMaca.text = vMaca.ToString();
                break;

            case 2:
                vLaranja--;
                txtLaranja.text = vLaranja.ToString();
                break;

            case 3:
                vAbacaxi--;
                txtAbacaxi.text = vAbacaxi.ToString();
                break;

            case 4:
                vBanana--;
                txtBanana.text = vBanana.ToString();
                break;
        }
    }
}
