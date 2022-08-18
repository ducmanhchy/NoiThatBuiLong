namespace BlogSystem.Data.Contracts
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        string UserCreate { get; set; }

        bool PreserveCreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        string UserModify { get; set; }
    }
}