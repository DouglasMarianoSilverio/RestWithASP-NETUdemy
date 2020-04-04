using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Extensions;
using RestWithASPNETUdemy.Helpers;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //GET api/
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (firstNumber.IsNumeric()&& secondNumber.IsNumeric())
            {
                decimal sum = Convertions.ConvertToDecimal(firstNumber) + Convertions.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("substraction/{firstNumber}/{secondNumber}")]
        public IActionResult Substraction(string firstNumber, string secondNumber)
        {
            if (firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                decimal substraction = Convertions.ConvertToDecimal(firstNumber) - Convertions.ConvertToDecimal(secondNumber);
                return Ok(substraction.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                decimal multiplication = Convertions.ConvertToDecimal(firstNumber) * Convertions.ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid input");
        }

        
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                decimal division = Convertions.ConvertToDecimal(firstNumber) / Convertions.ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                decimal mean = (Convertions.ConvertToDecimal(firstNumber) + Convertions.ConvertToDecimal(secondNumber))/2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{square-root}/{secondNumber}")]
        public IActionResult SquareRoot(string number)
        {
            if (number.IsNumeric())
            {
                var squareRoot = Math.Sqrt((double)Convertions.ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid input");
        }

       
    }
}