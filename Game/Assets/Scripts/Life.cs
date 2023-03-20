using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;

    [SerializeField] private float vidaTotal = 100f;
    public float vida;
    public bool vivo = true;

    int frameTotal;
    int frameAtual;
    int frameRef;

    SpriteRenderer sprite;

    Score score;

    void Start() {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        score = FindObjectOfType<Score>();
        vida = vidaTotal;
        frameAtual = 0;

        AnimationClip clip = animator.runtimeAnimatorController.animationClips[0]; // assume que há apenas uma animação no controller
        // Calcula o número total de frames
        float framesPorSegundo = clip.frameRate;
        float duracaoSegundos = clip.length;
        frameTotal = Mathf.RoundToInt(framesPorSegundo * duracaoSegundos);
        frameRef = (int)(vidaTotal / (vidaTotal / (frameTotal - 1)));
    }

    void Update(){
        if(vivo) Vida();
        else animator.Play("", 0, (1f / frameTotal) * frameAtual);
    }
    void Vida() {
        if (vida <= 0) {
            vida = 0;
            frameAtual = frameTotal - 1;
            boxCollider.enabled = false;
            sprite.color = new Color(1f, 1f, 1f, .5f);
            if (this.tag == "Navio") {
                if(this.GetComponent<Inimigo>().inimigoTipo == 0 )score.score += 20;
                else score.score += 10;
            }
            for (int i = 0; i < this.transform.childCount; i++) {
                if (this.transform.GetChild(i).gameObject.tag != "Range" && this.transform.GetChild(i).gameObject.tag != "BarraVida") {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                }else if (this.transform.GetChild(i).gameObject.tag == "BarraVida") {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                    this.transform.GetChild(i).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                }
            }
            vivo = false;
        } else {
            for (int i = frameRef; i > 0; i--) {
                if (vida > ((vidaTotal / frameRef) * i) - vidaTotal / frameRef) {
                    frameAtual = frameRef - i;
                    break;
                }
            }
            for (int i = 0; i < this.transform.childCount; i++) {
                if (this.transform.GetChild(i).gameObject.tag != "Range" && this.transform.GetChild(i).gameObject.tag != "BarraVida") {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                }else if (this.transform.GetChild(i).gameObject.tag == "BarraVida") {
                    this.transform.GetChild(i).transform.GetChild(0).gameObject.transform.localScale = new Vector3(vida / vidaTotal, 1, 1);
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    this.transform.GetChild(i).transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 11f);
                }
            }
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }
        animator.Play("", 0, (1f / frameTotal) * frameAtual);
    }

    public float GetVidaTotal() {
        return vidaTotal;
    }
}