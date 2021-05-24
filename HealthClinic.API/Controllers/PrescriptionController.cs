using HealthClinic.BLL.DTOs;
using HealthClinic.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthClinic.API.Controllers
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
                    return NotFound("Did not find any prescriptions with such id");
                }

                return Ok(prescr);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult AddPrescription(PrescriptionRequest request)
        {
            try
            {
                if (DateTime.Compare(request.DueDate, request.Date) < 0)
                {
                    return BadRequest("Invalid due date");
                }

                _context.AddPrescription(request);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrescription(int id)
        {
            try
            {
                _context.DeletePrescription(id);
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public IActionResult UpdatePrescription(PrescriptionRequest request)
        {
            try
            {
                if(request.IdPrescription == null)
                {
                    return BadRequest("Did not provide the prescription's ID");
                }

                Console.WriteLine(request.IdPrescription);
                if (DateTime.Compare(request.DueDate, request.Date) < 0)
                {
                    return BadRequest("Invalid due date");
                }

                _context.UpdatePrescription(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}