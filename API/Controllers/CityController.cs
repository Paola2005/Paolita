using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CityController : BaseController
    {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var Cityes = await _unitOfWork.Cities.GetAllAsync2();
        return _mapper.Map<List<CityDto>>(Cityes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CityDto>> Get(int id)
    {
        var City = await _unitOfWork.Cities.GetId(id);
        if (City == null)
        {
            return NotFound();
        }
        return _mapper.Map<CityDto>(City);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(CityDto CityDto)
    {
        var City = _mapper.Map<City>(CityDto);
        this._unitOfWork.Cities.Add(City);
        await _unitOfWork.SaveAsync();
        if (City == null)
        {
            return BadRequest();
        }
        CityDto.Id = City.Id;
        return CreatedAtAction(nameof(Post), new { id = CityDto.Id }, CityDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto CityDto)
    {
        if (CityDto == null)
            return NotFound();
        var Cityes = _mapper.Map<City>(CityDto);
        _unitOfWork.Cities.Update(Cityes);
        await _unitOfWork.SaveAsync();
        return CityDto;
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var City = await _unitOfWork.Cities.GetId(id);
        if (City == null)
        {
            return NotFound();
        }
        _unitOfWork.Cities.Remove(City);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
}