using Microsoft.AspNetCore.Mvc;

namespace Insurance.Libraries
{
    public struct ActionResults
    {
        public static IActionResult Ok()
        {
            return Ok();
        }
        public static IActionResult NotFound()
        {
            throw new NotImplementedException(); //Implement an appropriate custom NotFound ActionResult
        }
        public static IActionResult AlreadyExists()
        {
            throw new  ArgumentException();//Implement an appropriate custom AlreadyExists ActionResult
        }
        public static IActionResult InternalServerError()
        {
            throw new ArgumentException();//Implement an appropriate custom InternalServerError ActionResult
        }
    }
}
