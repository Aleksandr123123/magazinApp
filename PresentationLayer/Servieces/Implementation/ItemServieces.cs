using BusinessLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace PresentationLayer.Servieces.Implementation
{
    public class ItemServieces: IItemServieces
    {

        private UnitOfWork _unitOfWork;
     
        public ItemServieces(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ItemViewModel> GetItemsListToViewModel()
        {
            var items = _unitOfWork.Items.GetAll();
            List<ItemViewModel> model = new List<ItemViewModel>();
            foreach (var item in items)
            {
                model.Add(GetItemsDBToViewModelById(item.Id));
            }
            return model;
        }

        public ItemViewModel GetItemsDBToViewModelById(int itemId)
        {

            var items = _unitOfWork.Items.Get(itemId);
           var model = new ItemViewModel()
            {
               Id = items.Id,
               Name = items.Name,
                Code = items.Code,
                Price = items.Price,
                Category = items.Category,
             };
            return model;
        }

        public ItemViewModel SaveItemCreateModelToDb(ItemCreateModel createModel)
        {
            Item item = new Item()
            {
                Name = createModel.Name,
                Code = createModel.Code,
                Price = createModel.Price,
                Category = createModel.Category
            };
            _unitOfWork.Items.Create(item);
            return GetItemsDBToViewModelById(item.Id);
        }
     
        public ItemUpdateModel UpdateItemModel(ItemUpdateModel updateModel)
        {
            Item item = _unitOfWork.Items.Get(updateModel.Id);
            item.Name = updateModel.Name;
            item.Code = updateModel.Code;
            item.Price = updateModel.Price;
            item.Category = updateModel.Category;
            _unitOfWork.Items.Update(item);
            return updateModel;
        }

        public void DeleteItemModel(int id)
        {
            _unitOfWork.Items.Delete(id);

        }
    }
}

