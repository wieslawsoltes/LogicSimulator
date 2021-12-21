using System;

namespace Logic.Model.Core
{
    public interface IId
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
