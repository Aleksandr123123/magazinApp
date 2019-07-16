using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Servieces.Interfaces
{
    public interface IItemServieces
    {
        List<ItemViewModel> GetItemsListToViewModel();
    
        ItemViewModel GetItemsDBToViewModelById(int itemId);

        ItemViewModel SaveItemCreateModelToDb(ItemCreateModel createModel);

        ItemUpdateModel UpdateItemModel(ItemUpdateModel updateModel);

        void DeleteItemModel(int id);
    }
}
