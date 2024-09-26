namespace MarineWebsiteServer.WebAPI.DTOs.PortfolioDto;

public sealed record UpdatePortfolioDto(
    Guid Id,
    string Title,
    string Description,
    IFormFile? Image);
