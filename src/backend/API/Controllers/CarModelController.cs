using AutoMapper;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.DTOs.CarBrandDTOs;
using Models.DTOs.CarModelDTOs;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarModelController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarModelController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet("{id}", Name = nameof(GetCarModel))]
    public async Task<IActionResult> GetCarModel([FromRoute] Guid id)
    {
        var carModel = await _unitOfWork.CarModelsRepository.GetAsync(id);
        
        if (carModel is null) return NoContent();
        
        return Ok(_mapper.Map<CarModelDto>(carModel));
    }

    [HttpPost]
    public async Task<IActionResult> AddCarModel([FromBody] AddCarModelDto carModelDto)
    {
        var carBrand = await _unitOfWork.CarBrandsRepository
            .GetQueryable(cb => cb.Id == carModelDto.BrandId)
            .Include(cb => cb.CarModels)
            .FirstOrDefaultAsync();
        
        if (carBrand is null) 
            return BadRequest("CarBrandId is not valid");
        
        if (carBrand.CarModels.Any(c => c.Name == carModelDto.Name))
            return BadRequest("Car model name of one brand can't have similar name");
        
        var carModel = _mapper.Map<CarModel>(carModelDto);
        carModel.Brand = carBrand;
        
        await _unitOfWork.CarModelsRepository.AddAsync(carModel);

        if (await _unitOfWork.SaveChangesAsync() == false)
        {
            return BadRequest("CarModel couldn't be saved to db");
        }

        return CreatedAtRoute(nameof(GetCarModel), new { id = carModel.Id }, _mapper.Map<CarModelDto>(carModel));
    }
}
