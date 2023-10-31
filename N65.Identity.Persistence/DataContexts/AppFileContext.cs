﻿using FileBaseContext.Abstractions.Models.FileSet;
using N65.Identity.Domain.Entities;
using FileBaseContext.Context.Models.FileContext;
using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Context.Models.Configurations;
using N65.Identity.Domain.Common;

namespace N65.Identity.Persistence.DataContexts;

public class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public IFileSet<UserCredentials, Guid> UserCredentials => Set<UserCredentials, Guid>(nameof(UserCredentials)); 


    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
        OnSaveChanges += AddAuditableDetails;
        OnSaveChanges += AddSoftDeletionDetails;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<IEntity> entityEntry) continue;

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.Id = Guid.NewGuid();

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>>) continue;
            }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddAuditableDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<AuditableEntity> entityEntry) continue;

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.CreatedDate = DateTimeOffset.Now;

                if (entityEntry.State == FileEntityState.Modified)
                    entityEntry.Entity.ModifiedDate = DateTimeOffset.Now;

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>>) continue;
            }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddSoftDeletionDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                // Skip entities that are not soft deletable
                if (entry is not IFileEntityEntry<AuditableEntity> { State: FileEntityState.Deleted } entityEntry) continue;

                // Soft delete all entities except PostView
                entityEntry.Entity.IsDeleted = true;
                entityEntry.Entity.DeletedDate = DateTimeOffset.Now;
                entityEntry.State = FileEntityState.MarkedDeleted;
            }

        return new ValueTask(Task.CompletedTask);
    }
}