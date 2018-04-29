using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Payments.Data;
using Payments.Models;

namespace Payments.Controllers
{
    [Produces("application/json")]
    public class PaymentController : Controller
    {
        private readonly DataContext _context;
        public PaymentController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("v1/payments")]
        public IActionResult Post([FromBody]Payment payment)
        {
            _context.Payment.Add(payment);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("v1/payments")]
        public IActionResult Get()
        {
            return Ok(_context.Payment.ToList());
        }

        [HttpGet]
        [Route("v1/payments/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Payment.Find(id));
        }

        [HttpPut]
        [Route("v1/payments/{id}")]
        public IActionResult Put(int id, [FromBody]Payment payment)
        {
            Payment _payment = _context.Payment.Find(id);
            _payment.Title = payment.Title;
            _payment.Amount = payment.Amount;
            _payment.Paid = payment.Paid;
            _payment.Comments = payment.Comments;
            _payment.Payday = payment.Payday;

            _context.Entry(_payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("v1/payments/{id}")]
        public IActionResult Delete(int id)
        {
            _context.Payment.Remove(_context.Payment.Find(id));
            _context.SaveChanges();

            return Ok();
        }
    }
}