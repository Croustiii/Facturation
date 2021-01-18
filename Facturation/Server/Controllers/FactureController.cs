using Facturation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactureController : ControllerBase
    {

        private readonly ILogger<FactureController> logger;
        private readonly IBusinessData businessData;

        public FactureController(ILogger<FactureController> logger, IBusinessData data)
        {
            this.logger = logger;
            businessData = data;
        }

        [HttpGet]
        public IEnumerable<Facture> Get()
        {
            return businessData.AllFactures;

        }

        [HttpGet("{reference}")]
        public ActionResult<Facture> Get(string reference)
        {
            var facture = businessData.AllFactures.Where(inv => inv.Reference == reference).FirstOrDefault();

            if (facture != null)
            {
                return facture;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Facture> Post([FromQuery] Facture facture)
        {
            if (ModelState.IsValid)
            {
                // TODO : Ajouter la nouvelle facture à la collection
                return Created($"invoices/{facture.Reference}", facture);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
