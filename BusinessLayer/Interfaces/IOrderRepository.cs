using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        int Count();
    }
}
