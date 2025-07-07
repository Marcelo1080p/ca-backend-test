using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IBillingAppService _billingAppService;

        public BillingController(IBillingAppService billingAppService)
        {
            _billingAppService = billingAppService;
        }

        [HttpPost("import-external")]
        public async Task<IActionResult> ImportFromExternalApiAsync()
        {
            try
            {
                await _billingAppService.ImportBillingFromExternalApiAsync();
                return Ok(new { message = "Importação realizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
