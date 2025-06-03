using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AntlrCalculator.WinForms;

namespace AntlrCalculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpPost("calculate")]
    public ActionResult<double> Calculate([FromBody] CalculationRequest request)
    {
        try
        {
            var result = CalculatorHelper.Calculate(request.Expression);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("version")]
    public ActionResult<string> GetVersion()
    {
        return Ok(CalculatorHelper.GetVersion());
    }

    public class CalculationRequest
    {
        [Required]
        public string Expression { get; set; } = string.Empty;
    }
} 