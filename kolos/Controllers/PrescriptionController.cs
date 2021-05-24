﻿using kolos.DTOs;
using kolos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController: ControllerBase
    {
        private readonly IDbContext _context;
        public PrescriptionController(IDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetPrescription(int id)
        {
            try
            {
                var prescr = _context.GetPrescription(id);
                if (prescr == null)
                {
                    NotFound("Did not find prescriptions with such id");
                }
                return Ok(prescr);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost()]
        public IActionResult AddPrescription(PrescriptionRequest request)
        {
            if (DateTime.Compare(request.DueDate, request.Date) < 0)
            {
                return BadRequest("Invalid due date");
            }
            _context.AddPrescription(request);
            
            return Ok();
        }
    }
}