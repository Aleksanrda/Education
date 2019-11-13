using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creeperscare.API.Models;
using Creeperscare.DAL.Services;
using Creeperscare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Creeperscare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly CreeperscareDbContext _context;

        public SubscriptionsController(CreeperscareDbContext context)
        {
            _context = context;
        }

        // GET: api/Subscriptions
        [HttpGet]
        [ProducesResponseType(typeof(SubscriptionModel[]), StatusCodes.Status200OK)]
        public IEnumerable<SubscriptionModel> GetSubscriptions()
        {
            var subscriptionModels = _context.Subscriptions.Select(x =>
            new SubscriptionModel()
            {
                SubscriptionId = x.SubscriptionId,
                IdentificationName = x.IdentificationName,
                Price = x.Price
            }).ToList();

            return subscriptionModels;
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SubscriptionModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubscription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            var subscriptionModel = new SubscriptionModel()
            {
                SubscriptionId = subscription.SubscriptionId,
                IdentificationName = subscription.IdentificationName,
                Price = subscription.Price
            };

            return Ok(subscriptionModel);
        }

        // PUT: api/Subscriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription([FromRoute] int id, [FromBody] SubscriptionModel subscriptionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriptionModel.SubscriptionId)
            {
                return BadRequest();
            }
            var subscription = await _context.Subscriptions.FindAsync(subscriptionModel.SubscriptionId);

            subscription.IdentificationName = subscriptionModel.IdentificationName;
            subscription.Price = subscriptionModel.Price;
            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subscriptions
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostSubscription([FromBody] SubscriptionModel subscriptionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subscription = new Subscription()
            {
                IdentificationName = subscriptionModel.IdentificationName,
                Price = subscriptionModel.Price
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscription", new { id = subscriptionModel.SubscriptionId }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteSubscription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();

            return Ok(subscription);
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionId == id);
        }
    }
}
