using UnityEngine;


public class MenuManager : MonoBehaviour
{
    
    public GameObject[] items;
    private Transform camTrans;
    public void MakeItem(int itemNum)
    {
        //camera forward - where it's pointing to
        Vector3 position = Camera.main.transform.position + Camera.main.transform.forward;
        Instantiate(items[itemNum], position, Quaternion.identity);
    }
}
