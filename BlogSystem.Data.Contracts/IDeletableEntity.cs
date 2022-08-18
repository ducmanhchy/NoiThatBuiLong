namespace BlogSystem.Data.Contracts
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        string UserDelete { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}