using System;

namespace FaqBuilder.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}