﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionController : Controller
    {
       
        private readonly IRegionRepository _regionRepository;

        private IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions =await _regionRepository.GetallRegionsAsync();

            var regionDto = new List<RegionDto>();

            regions.ToList().ForEach(obj =>
            {
                var regionsDto = new Model.DTO.RegionDto()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Area = obj.Area,
                    Lat = obj.Lat,
                    Long = obj.Long,
                    Population = obj.Population
                };

                regionDto.Add(regionsDto);

            });

            //var regionDto = _mapper.Map<List<Model.DTO.RegionDto>>(regions);

            return  Ok(regionDto);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region =  await _regionRepository.GetRegionsbyId(id);

            if(region == null)
            {
                return NotFound();
            }


             var mapper = _mapper.Map<RegionDto>(region);

             return Ok(mapper);

            
        }

        [HttpPost]
        public async Task<IActionResult> AddRegions(AddRegionDTO add)
        {
            var region = new Regions()
            {
                Name = add.Name,
                Code = add.Code,
                Lat = add.Lat,
                Long = add.Long,
                Area = add.Area,
                Population = add.Population
            };

          region =  await _regionRepository.AddRegion(region);


            var regionDto = new RegionDto()
            {

                Name = region.Name,
                Code = region.Code,
                Lat = region.Lat,
                Long = region.Long,
                Area = region.Area,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);

        }

        //[HttpDelete]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> DeleteRegionsAsync(Guid id)
        //{
        //   var region =  await _regionRepository.DeleteRegion(id);

        //    if(region == null)
        //    {
        //        return NotFound(region);
        //    }

        //    var regionDto = new RegionDto()
        //    {
        //        Name = region.Name,
        //        Code = region.Code,
        //        Lat = region.Lat,
        //        Long = region.Long,
        //        Area = region.Area,
        //        Population = region.Population

                

        //    };

        //    return Ok(regionDto);


        //}
    }
}