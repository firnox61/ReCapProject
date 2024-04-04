using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result= _paymentService.Get(id);
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetCustomerByPayment")]
        public IActionResult GetCustomerByPayment(int customerId) 
        {
            var result=_paymentService.GetCustomerByPayment(customerId);
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
           var result= _paymentService.Add(payment);
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Payment payment) 
        {
            var result=_paymentService.Delete(payment);
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Payment payment) 
        {
            var result=_paymentService.Update(payment);
            if(result.Success==true)
            {
                return Ok(result);
            }
                return BadRequest();
        }
    }
}
