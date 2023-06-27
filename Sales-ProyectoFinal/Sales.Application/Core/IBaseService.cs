using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Core
{
    public interface IBaseService <TDtoAdd, TDtoUpdate, TDtoRemove> 
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Save(TDtoAdd model);
        ServiceResult Update(TDtoUpdate model);
        ServiceResult Remove(TDtoRemove model);

    }
}
