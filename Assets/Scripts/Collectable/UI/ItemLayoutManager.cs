using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Item
{
    public class ItemLayoutManager : MonoBehaviour
    {
        public ItemLayout prefabLayout;
        public Transform container;
        public List<ItemLayout> itemLayouts;
        private void Start()
        {
            CreateItems();
        }
        private void CreateItems()
        {
            foreach(var setup in ItemManager.Instance.itemSetups)
            {
                var item = Instantiate(prefabLayout, container);
                item.load(setup);
                itemLayouts.Add(item);
            }
        }
    }
}
