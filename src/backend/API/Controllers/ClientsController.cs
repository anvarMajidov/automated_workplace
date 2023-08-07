using AutoMapper;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs.ClientDTOs;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet("{id}", Name = nameof(GetClient))]
    public async Task<IActionResult> GetClient([FromRoute] Guid id)
    {
        var client = await _unitOfWork.ClientsRepository.GetAsync(id);
        
        if (client is null) return NoContent();
        
        return Ok(_mapper.Map<ClientDto>(client));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddClient([FromBody] AddClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
        
        await _unitOfWork.ClientsRepository.AddAsync(client);
        
        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("Client couldn't be saved to db");
        }
        
        return CreatedAtRoute(nameof(GetClient), new { id = client.Id }, clientDto);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClientDto clientDto)
    {
        var client = await _unitOfWork.ClientsRepository.GetAsync(clientDto.Id);

        if (client is null) return NoContent();

        _unitOfWork.ClientsRepository.Update(client);
        
        client = _mapper.Map<Client>(clientDto);
        
        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("No Changes were made");
        }
        
        return Ok(_mapper.Map<ClientDto>(client));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var client = await _unitOfWork.ClientsRepository.GetAsync(id);

        if (client is null) return NoContent();

        _unitOfWork.ClientsRepository.Delete(client);

        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("Client couldn't be deleted from database");
        }
        
        return Ok();
    }
}
