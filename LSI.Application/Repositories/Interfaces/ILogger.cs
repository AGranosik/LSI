using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Application.Repositories.Interfaces
{
    public interface ILogger
    {
        Task LogException(Exception ex);
    }
}
