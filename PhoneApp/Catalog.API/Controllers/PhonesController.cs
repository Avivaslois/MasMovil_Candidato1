﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.ControllerWorkers;
using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class PhonesController : Controller
    {
        private readonly InterfacePhoneCW _phoneCW;

        public PhonesController(InterfacePhoneCW phoneCW)
        {
            _phoneCW = phoneCW;
        }


        // GET api/phones
        [HttpGet]
        public IEnumerable<PhoneDto> Get()
        {
            var result = _phoneCW.getPhones();
            return result;
        }

        // GET api/phones/1
        [HttpGet("{id}")]
        public PhoneDto Get(int id)
        {
            var result = _phoneCW.getPhoneById(id);
            return result;
        }

        //POST api/phones
        //ids: JSON Parameter in body
        [HttpPost]
        public List<PhonePriceDto> Post([FromBody]List<int> ids)
        {
            var result = _phoneCW.getPricesByIds(ids);
            return result;
        }
    }
}
