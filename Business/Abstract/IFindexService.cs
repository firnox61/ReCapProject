using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFindexService
    {
        IDataResult<int> GetCustomerFindexScore(int customerId);
        IDataResult<int> GetCarMinFindexScore(int carId);
    }
}
