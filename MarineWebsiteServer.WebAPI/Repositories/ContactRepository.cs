using ED.Result;
using MarineWebsiteServer.WebAPI.Context;
using MarineWebsiteServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarineWebsiteServer.WebAPI.Repositories;

public sealed class ContactRepository(
    ApplicationDbContext context)
{
    public async Task<Result<string>> Create(Contact contact, CancellationToken cancellationToken)
    {
        await context.AddAsync(contact, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Mail Gönderildi");
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        Contact? contact = GetById(Id);
        if (contact is null)
        {
            return Result<string>.Failure("Contact kaydı bulunamadı");
        }

        contact.IsDeleted = true;
        context.Update(contact);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Contact silme işlemi başarılı");
    }

    public async Task<Result<List<Contact>>> GetAll(CancellationToken cancellationToken)
    {
        var contacts = await context.Contacts.Where(p => !p.IsDeleted).OrderByDescending(o => o.CreatedDate).ToListAsync(cancellationToken);
        return Result<List<Contact>>.Succeed(contacts);
    }

    public Contact? GetById(Guid Id)
    {
        return context.Contacts.Where(p => p.Id == Id).FirstOrDefault();
    }

    public async Task<Result<string>> Update(Contact contact, CancellationToken cancellationToken)
    {
        context.Update(contact);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Contact güncelleme işlemi başarılı");
    }
}
