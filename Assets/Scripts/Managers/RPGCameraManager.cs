using UnityEngine;
using Cinemachine;

/// <summary>
/// classe criada para guardar a intancia da camera que seguira o player
/// </summary>
public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager instanciaCompartilhada = null;

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    
    /* cria instancia da camera a ser vinculada ao player em RPGGameManager */
    void Start()
    {
        if (instanciaCompartilhada != null && instanciaCompartilhada != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
        GameObject vCamGameObject = GameObject.Find("CM vcam1");
        print(vCamGameObject);
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
