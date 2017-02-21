using ProductivityTracker_Business.Executors;
using ProductivityTracker_Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Business
{
    public static class ExecutorFacade
    {
        public static ILoginExecutor GetLoginInstance()
        {
            return new LoginExecutor();
        }
    }
}
