using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.CQRS.Queries
{
    public class QueryResponse<TResult>
    {
        public TResult Result { get; private set; }
        public bool Success { get; private set; }

        public QueryResponse(TResult result, bool success)
        {
            Result = result;
            Success = success;
        }
    }
}
