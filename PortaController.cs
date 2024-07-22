using UnityEngine;

public class PortaController : MonoBehaviour
{
    public SpriteRenderer portaSuperiorSpriteRenderer; // Sprite Renderer da parte superior da porta
    public SpriteRenderer portaInferiorSpriteRenderer; // Sprite Renderer da parte inferior da porta
    public Sprite portaSuperiorFechadaSprite; // Sprite da parte superior da porta fechada
    public Sprite portaInferiorFechadaSprite; // Sprite da parte inferior da porta fechada
    public Sprite portaSuperiorAbertaSprite; // Sprite da parte superior da porta aberta
    public Sprite portaInferiorAbertaSprite; // Sprite da parte inferior da porta aberta
    public Collider2D portaSuperiorCollider; // Collider da parte superior da porta
    public Collider2D portaInferiorCollider; // Collider da parte inferior da porta
    public int chavesNecessarias = 10; // Quantidade de chaves necessárias para abrir a porta
    private bool portaAberta = false;
    private ColetarChave coletarChaveScript; // Referência ao script que coleta chaves

    void Start()
    {
        portaSuperiorSpriteRenderer.sprite = portaSuperiorFechadaSprite;
        portaInferiorSpriteRenderer.sprite = portaInferiorFechadaSprite;
        coletarChaveScript = FindObjectOfType<ColetarChave>();
    }

    void Update()
    {
        if (!portaAberta && coletarChaveScript.chavesColetadas >= chavesNecessarias && Input.GetButtonDown("Interage"))
        {
            AbrirPorta();
        }
    }

    void AbrirPorta()
    {
        portaAberta = true;

        // Atualiza os sprites para os sprites da porta aberta
        portaSuperiorSpriteRenderer.sprite = portaSuperiorAbertaSprite;
        portaInferiorSpriteRenderer.sprite = portaInferiorAbertaSprite;

        // Remove os colliders para permitir a passagem
        if (portaSuperiorCollider != null)
        {
            Destroy(portaSuperiorCollider);
        }
        if (portaInferiorCollider != null)
        {
            Destroy(portaInferiorCollider);
        }
    }
}
