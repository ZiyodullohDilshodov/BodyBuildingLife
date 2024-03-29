﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;
using BodyBuildingLife.Service.Interfaces.PersonTrainer;

namespace BodyBuildingLife.Api.Controllers.PersonTrainer;

public class PersonTrainerController : BaseController
{
    private readonly IPersonTrainerService _personTrainerService;

    public PersonTrainerController(IPersonTrainerService personTrainerService)
    {
        _personTrainerService = personTrainerService;
    }

    [HttpGet("{personTrainer-id}")]
    public async Task<IActionResult> GetByIDAsync([FromRoute(Name = "personTrainer-id")] long id)
    {
        var personTrainer = await _personTrainerService.RetruveByIdAsync(id);
        return Ok(personTrainer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var personTrainer = await _personTrainerService.RetrieveAllAsync();
        return Ok(personTrainer);
    }

    [HttpDelete("{personTrainer-id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "personTrainer-id")] long id)
    {
        var personTrainer = await _personTrainerService.DeleteAsync(id);
        return Ok(personTrainer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([Required]PersonTrainerForCreationDto personTrainerForCreationDto)
    {
        var personTrainer = await _personTrainerService.CreateAsync(personTrainerForCreationDto);
        return Ok(personTrainer);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] PersonTrainerForUpdateDto personTrainerForUpdateDto)
    {
        var personTrainer = await _personTrainerService.UpdateAsync(personTrainerForUpdateDto);
        return Ok(personTrainer);
    }
}
