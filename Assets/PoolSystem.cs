using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public int m_nbItemToCreate;

    public PoolItem m_item;

    private List<PoolItem> m_itemList = new List<PoolItem>();

    // Start is called before the first frame update
    void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for (var i = 0; i < m_nbItemToCreate; i++)
        {
            var newItem = CreateNewItem();
            
            m_itemList.Add(newItem);
        }
    }

    private PoolItem CreateNewItem()
    {
        var item = Instantiate(m_item, Vector3.zero, Quaternion.identity);
        item.transform.SetParent(transform);
        
        item.Init();

        return item;
    }

    public PoolItem GetFirstAvailableItem()
    {
        foreach (var item in m_itemList)
        {
            if (item.IsAvailable) return item;
        }

        return CreateNewItem();

    }
    
}
