using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Application.Handlers.Contracts
{
    public interface IHandler<TRequest,TResponse>
    {
        Task<TResponse> Handle(TRequest request);
        
    }
}