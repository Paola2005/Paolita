using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{

    public class PersonTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonType>>> Get()
        {
            var entidades = await _unitOfWork.PersonsTypes.GetAllAsync();
            return _mapper.Map<List<PersonType>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Get(int id)
        {
            var entidad = await _unitOfWork.PersonsTypes.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonTypeDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonType>> Post(PersonTypeDto PersonTypeDto)
        {
            var entidad = _mapper.Map<PersonType>(PersonTypeDto);
            this._unitOfWork.PersonsTypes.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            PersonTypeDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = PersonTypeDto.Id}, PersonTypeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto PersonTypeDto)
        {
            if(PersonTypeDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<PersonType>(PersonTypeDto);
            _unitOfWork.PersonsTypes.Update(entidades);
            await _unitOfWork.SaveAsync();
            return PersonTypeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.PersonsTypes.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.PersonsTypes.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}