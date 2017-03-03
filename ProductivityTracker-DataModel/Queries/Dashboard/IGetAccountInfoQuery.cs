using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataModel.Core;
using ProductivityTracker_Models.Dto.Dashboard;

namespace ProductivityTracker_DataModel.Queries.Dashboard
{
    public interface IGetAccountInfoQuery : IQuery
    {
        List<AccountInfoDto> Execute(int projectId);
    }
}
