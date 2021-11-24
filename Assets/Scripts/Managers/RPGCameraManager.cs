using UnityEngine;
using Cinemachine;

public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager instanciaCompartilhada = null;

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
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
