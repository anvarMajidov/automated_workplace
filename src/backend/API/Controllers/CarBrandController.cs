using AutoMapper;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.DTOs.CarBrandDTOs;
using Models.DTOs.CarDTOs;
using static System.String;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarBrandController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarBrandController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet("{id}", Name = nameof(GetCarBrand))]
    public async Task<IActionResult> GetCarBrand([FromRoute] Guid id)
    {
        var carBrand = await _unitOfWork.CarBrandsRepository.GetAsync(id);
        
        if (carBrand is null) return NoContent();
        
        return Ok(_mapper.Map<CarBrandDto>(carBrand));
    }

    [HttpPost]
    public async Task<IActionResult> AddCarBrand([FromBody] AddCarBrandDto carBrandDto)
    {
        var carBrandExist = await _unitOfWork.CarBrandsRepository
            .GetQueryable(cb => cb.Name.ToLower() == carBrandDto.Name.ToLower())
            .AnyAsync();
        
        if (carBrandExist)
        {
            return BadRequest("Brand with given name already exists");
        }
        
        var carBrand = _mapper.Map<CarBrand>(carBrandDto);

        await _unitOfWork.CarBrandsRepository.AddAsync(carBrand);
        
        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("Client couldn't be saved to db");
        }
        
        return CreatedAtRoute(nameof(GetCarBrand), new { id = carBrand.Id }, _mapper.Map<CarBrandDto>(carBrand));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var carBrand = await _unitOfWork.CarBrandsRepository.GetAsync(id);

        if (carBrand is null) return NoContent();

        _unitOfWork.CarBrandsRepository.Delete(carBrand);
        
        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("CarBrand couldn't be deleted from database");
        }
        
        return Ok();
    }
}
