using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.Core;
using ProductivityTracker_DataModel.Queries.Projects;
using ProductivityTracker_Models.Dto.Projects;

namespace ProductivityTracker_DataAccess.QueryExecutors.Project
{
    public class GetProjectsForDropdownQuery: QueryBase<SqlServerContext>, IGetProjectsForDropdownQuery
    {
        public GetProjectsForDropdownQuery(SqlServerContext dbContextInput) : base(dbContextInput)
        {
        }

        public List<ProjectDropdownDto> Execute()
        {
            return dbContext.ProjectDetails.Select(var => new ProjectDropdownDto
            {
                ProjectId = var.Id,
                ProjectName = var.ProjectName
            }).ToList();
        }
    }
}
