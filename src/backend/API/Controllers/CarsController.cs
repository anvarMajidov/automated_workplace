using AutoMapper;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs.CarDTOs;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] AddCarDto carDto)
    {
        var user = await _unitOfWork.ClientsRepository.GetAsync(carDto.ClientId);
        if (user is null) return BadRequest("UserId is not valid");
        
        var carBrand = await _unitOfWork.CarBrandsRepository.GetAsync(carDto.CarBrandId);
        if (carBrand is null) return BadRequest("CarBrandId is not valid");
        
        var carModel = await _unitOfWork.CarModelsRepository.GetAsync(carDto.CarModelId);
        if (carModel is null) return BadRequest("CarModelId is not valid");
        
        var car = _mapper.Map<Car>(carDto);
        
        car.CarBrand = carBrand;
        car.CarModel = carModel;
        
        await _unitOfWork.CarsRepository.AddAsync(car);

        if (await _unitOfWork.SaveChangesAsync())
        {
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, carDto);
        }

        return BadRequest("Couldn't save to db");
    }
    
    [HttpGet("{id}", Name = nameof(GetCar))]
    public async Task<IActionResult> GetCar([FromRoute] Guid id)
    {
        var car = await _unitOfWork.CarsRepository.GetAsync(id);
        
        if (car is null) return NoContent();
        
        return Ok(_mapper.Map<CarDto>(car));
    }
}
