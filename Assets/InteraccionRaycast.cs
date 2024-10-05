using UnityEngine;

public class InteraccionRaycast : MonoBehaviour
{
    public float distanciaInteraccion = 5f;  // Distancia máxima a la que se puede interactuar con objetos.
    private Transform objetoActual;  // El objeto actualmente interactuado.
    private Renderer objetoRenderer;  // Renderer del objeto interactuado para cambiar el material.
    public Material outlineMaterial;  // El material de contorno que vamos a aplicar.
    private Material originalMaterial;  // Para guardar el material original del objeto.

    void Update()
    {
        DetectarObjetoInteractivo();
    }

    void DetectarObjetoInteractivo()
    {
        // Crear un raycast desde la posición del jugador hacia adelante.
        Ray ray = new Ray(transform.position, transform.forward);

        // Información del impacto del raycast.
        RaycastHit hit;

        // Si el raycast impacta un objeto en la distancia definida.
        if (Physics.Raycast(ray, out hit, distanciaInteraccion))
        {
            // Si el objeto tiene la etiqueta "Interactivo", lo consideramos interactuable.
            if (hit.collider.CompareTag("Interactivo"))
            {
                // Comprobamos si estamos mirando un objeto diferente.
                if (hit.transform != objetoActual)
                {
                    // Si había un objeto anterior, restauramos su material original.
                    if (objetoActual != null)
                    {
                        RestablecerMaterial();
                    }

                    // Actualizamos el nuevo objeto.
                    objetoActual = hit.transform;
                    objetoRenderer = objetoActual.GetComponent<Renderer>();

                    if (objetoRenderer != null)
                    {
                        // Guardamos el material original del objeto.
                        originalMaterial = objetoRenderer.material;

                        // Aplicamos el material con contorno.
                        objetoRenderer.material = outlineMaterial;
                    }
                }
            }
            else
            {
                // Si no estamos mirando un objeto interactuable, restauramos el material del anterior.
                RestablecerMaterial();
            }
        }
        else
        {
            // Si el raycast no impacta nada, también restauramos el material.
            RestablecerMaterial();
        }
    }

    void RestablecerMaterial()
    {
        if (objetoActual != null && objetoRenderer != null)
        {
            // Restaurar el material original.
            objetoRenderer.material = originalMaterial;
        }

        // Limpiar la referencia al objeto.
        objetoActual = null;
    }
}