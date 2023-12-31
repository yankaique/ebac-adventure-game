using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

namespace Item
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager>
    {
       
        public List<ItemSetup> itemSetups;

        private void Start()
        {
            Reset();
            LoadItemsFrontSave();
        }

        private void Reset()
        {
            foreach (var i in itemSetups)
            {
                i.soInt.value = 0;
            }
        }

        public ItemSetup GetItemByType(ItemType itemType)
        {
            return itemSetups.Find(i => i.itemType == itemType);
        }

        private void LoadItemsFrontSave()
        {
            try
            {

               AddByType(ItemType.COIN, SaveManager.Instance.Setup.coins);
               AddByType(ItemType.LIFE_PACK, SaveManager.Instance.Setup.health);
            }
            catch
            {
                AddByType(ItemType.COIN, 0);
                AddByType(ItemType.LIFE_PACK, 0);
            }
        }

        public void AddByType(ItemType itemType, int amount =1)
        {
            if (amount < 0) return;
            itemSetups.Find(i=> i.itemType  == itemType).soInt.value += amount;
        }
        
        public void RemoveByType(ItemType itemType, int amount = 1)
        {
            var item = itemSetups.Find(i=> i.itemType  == itemType);
            item.soInt.value -= amount;

            if( item.soInt.value < 0 ) item.soInt.value = 0;
        }

        [NaughtyAttributes.Button]
        public void AddCoins(int amount = 1)
        {
           AddByType(ItemType.COIN, amount);
        }

        [NaughtyAttributes.Button]
        public void AddLifePacks(int amount = 1)
        {
            AddByType(ItemType.LIFE_PACK, amount);
        }
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }
}
