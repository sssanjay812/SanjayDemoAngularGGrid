using System.Collections.Generic;
using System.Linq;
using Items.Business.DAL.Entities;
using Items.Business.Services.Interfaces;

namespace Items.Business.Services
{
    /// <summary>
    /// Interface resolved by simple injector
    /// </summary>
    public interface IItemsService : IService<Add_Item>
    { }

    /// <summary>
    /// Mock service to simulate the database access layer
    /// </summary>
    public class ItemsService : IItemsService
    {
        #region Auto increment index

        private static int autoIncrementIndex = 0;

        private static int GetIndex()
        {
            autoIncrementIndex++;
            return autoIncrementIndex;
        }

        #endregion


        // Mock database with some sample data
        private static readonly List<Add_Item> mockDatabase = new List<Add_Item>
        {
            new Add_Item{Id = GetIndex(),    Name = "Sanjay",           Desc = "1",},
            new Add_Item{Id = GetIndex(),    Name = "Demo",          Desc = "2",},

        };

        public Add_Item Add(Add_Item item)
        {
            mockDatabase.Add(item);
            item.Id = GetIndex();
            return item;
        }

        public Add_Item Get(int id)
        {
            return mockDatabase.SingleOrDefault(item => item.Id == id);
        }

        public Add_Item Get(string name)
        {
            return mockDatabase.SingleOrDefault(item => item.Name == name);
        }

        public IEnumerable<Add_Item> GetAll()
        {
            return mockDatabase;
        }

        public bool Update(Add_Item updatedItem)
        {
            // Null check
            if (updatedItem == null) return false;

            // Item must exists
            if (!this.Any(updatedItem.Id)) return false;

            var serverItem = mockDatabase.Find(item => item.Id == updatedItem.Id);

            serverItem.Name = updatedItem.Name;
            serverItem.Desc = updatedItem.Desc;

            return true;
        }

        public bool Remove(int id)
        {
            var itemToRemove = mockDatabase.SingleOrDefault(item => item.Id == id);
            if (itemToRemove == null) return false;
            return mockDatabase.Remove(itemToRemove);
        }

        public bool Remove(string name)
        {
            var itemToRemove = this.Get(name);
            if (itemToRemove == null)
                return false;

            return this.Remove(itemToRemove.Id);
        }

        public bool Any(int id)
        {
            return mockDatabase.Any(item => item.Id == id);
        }

        public bool Any(string name)
        {
            return mockDatabase.Any(item => item.Name == name);
        }

        public void Dispose()
        {
            mockDatabase.Clear();
        }
    }
}