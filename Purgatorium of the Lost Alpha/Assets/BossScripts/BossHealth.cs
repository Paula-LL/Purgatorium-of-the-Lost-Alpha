using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Ajustes de Vida")]
    [Tooltip("Vida máxima del boss.")]
    [SerializeField] private float vidaMaxima = 500f;

    private float vidaActual;

    public float VidaActual => vidaActual;
    public float VidaMaxima => vidaMaxima;
    public bool  EstaMuerto => vidaActual <= 0f;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        if (EstaMuerto) return;

        vidaActual -= cantidad;
        vidaActual  = Mathf.Max(vidaActual, 0f);

        Debug.Log($"[BossHealth] {gameObject.name} recibió {cantidad} de daño. Vida: {vidaActual}/{vidaMaxima}");

        if (vidaActual <= 0f)
            Morir();
    }

    private void Morir()
    {
        Debug.Log($"[BossHealth] {gameObject.name} ha muerto.");
        // TODO: animación de muerte, desactivar IA, Destroy(gameObject, 3f), etc.
    }

    // TODO: Cuando esté disponible el script del jugador, llamar a RecibirDanio()
    // desde el collider/arma del jugador. Ejemplo:
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("ArmaJugador"))
    //     {
    //         Player_controller pc = other.GetComponentInParent<Player_controller>();
    //         float dmg = pc != null ? pc.danioAtaque : 10f;
    //         RecibirDanio(dmg);
    //     }
    // }
}
