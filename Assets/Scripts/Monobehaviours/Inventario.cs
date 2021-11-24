
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public GameObject slotPrefab;   // objeto que recebe o prefab slot
    public const int numSlots = 5;  // numero fixo de slots
    Image[] itemImagens = new Image[numSlots];      // array de imagens
    Item[] items = new Item[numSlots];              // array de items
    GameObject[] slots = new GameObject[numSlots];  // array de slots

    // Start is called before the first frame update
    void Start()
    {
        CriaSlots();
    }

    public void CriaSlots(){
        if (slotPrefab != null){
            for (int i=0; i <numSlots; i++){
                GameObject novoSlot = Instantiate(slotPrefab);
                novoSlot.name = "ItemSlot_" + i;
                novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = novoSlot;
                itemImagens[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    /*
     * A função AddItem tem como principal objetivo adicionar o item no inventário. Checando se tem inventario
     * disponivel, verificando se o item é empilhavel para armazena-lo no mesmo inventário que outro item do
     * mesmo tipo
     * (bug [CORRIGIDO]: caso fosse coletado um único item, mesmo que empilhavel, o marcador de quantidade iria marcar "00".)
     * (bug [CORRIGIDO]: a quantidade especificado no ScriptableObject não era respeitada.)
     */ 
    public bool AddItem(Item itemToAdd){
        for (int i=0; i<items.Length; i++){
            if (items[i] != null && items[i].tipoItem == itemToAdd.tipoItem && itemToAdd.empilhavel == true){
                items[i].quantidade = items[i].quantidade + itemToAdd.quantidade;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantidadeTexto = slotScript.qtdTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = items[i].quantidade.ToString();
                return true;
            }
            if (items[i] == null){
                items[i] = Instantiate(itemToAdd);
                items[i].quantidade = itemToAdd.quantidade;
                itemImagens[i].sprite = itemToAdd.sprite;
                itemImagens[i].enabled = true;
                if (itemToAdd.empilhavel)       // Neste if verifico se o item é empilhavel para modificar o texto abaixo do item, caso o item seja empilhavel.                      
                {
                    Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                    Text quantidadeTexto = slotScript.qtdTexto;
                    quantidadeTexto.enabled = true;
                    quantidadeTexto.text = items[i].quantidade.ToString();
                }
                return true;
            }
        }
        return false;
    }
}
