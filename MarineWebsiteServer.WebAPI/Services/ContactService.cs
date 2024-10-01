using AutoMapper;
using ED.GenericEmailService.Models;
using ED.GenericEmailService;
using ED.Result;
using MarineWebsiteServer.WebAPI.DTOs.ContactDto;
using MarineWebsiteServer.WebAPI.Models;
using MarineWebsiteServer.WebAPI.Repositories;

namespace MarineWebsiteServer.WebAPI.Services;

public sealed class ContactService(
    ContactRepository contactRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateContactDto request, CancellationToken cancellationToken)
    {
        Contact contact = mapper.Map<Contact>(request);
        contact.CreatedBy = request.FullName;
        contact.CreatedDate = DateTime.Now;

        //string body = CreateBody(contact);
        //string subject = contact.Subject;

        //EmailConfigurations emailConfigurations = new(
        //   "mail.erendelibas.com",
        //   "*****",
        //   587,
        //   false,
        //   true);

        //EmailModel<Stream> emailModel = new(
        //    emailConfigurations,
        //    "info@erendelibas.com",
        //    new List<string> { "info@erendelibas.com" ?? "" },
        //    subject,
        //    body,
        //    null);

        //await EmailService.SendEmailWithMailKitAsync(emailModel);

        return await contactRepository.Create(contact,cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        return await contactRepository.DeleteById(id,cancellationToken);
    }

    public async Task<Result<List<Contact>>> GetAll(CancellationToken cancellationToken)
    {
        return await contactRepository.GetAll(cancellationToken);
    } 

    public async Task<Result<string>> Update(UpdateContactDto request, CancellationToken cancellationToken)
    {
        Contact? contact = contactRepository.GetById(request.Id);
        if (contact == null)
        {
            return Result<string>.Failure("Contact kaydı bulunamadı");
        }

        contact.IsRead = request.IsRead;
        contact.UpdatedBy = "Admin";
        contact.UpdatedDate = DateTime.Now;
        return await contactRepository.Update(contact,cancellationToken);
    }

    private string CreateBody(Contact contact)
    {
        string body = $@"
<h4>Gönderen Adı: {contact.FullName}</h3>
<h4>Gönderen Email: {contact.Email}</h3>
<h3>Mesaj: {contact.Message}</h2>";
        return body;
    }
}
