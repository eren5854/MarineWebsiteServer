namespace MarineWebsiteServer.WebAPI.DTOs.PortfolioDto;

public sealed record CreatePortfolioDto(
    string Title,
    string Description,
    IFormFile? Image);
