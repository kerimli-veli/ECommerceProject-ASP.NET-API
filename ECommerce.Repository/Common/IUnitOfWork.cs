﻿using ECommerce.Repository.Repository;

namespace ECommerce.Repository.Common;

public class IUnitOfWork
{
    public IProductsRepository ProductsRepostory { get; }
    public ICustomersRepository CategoryRepository { get; }

}
