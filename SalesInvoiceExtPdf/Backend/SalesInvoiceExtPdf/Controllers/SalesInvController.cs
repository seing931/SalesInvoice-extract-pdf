using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesInvoiceExtPdf.Data;
using SalesInvoiceExtPdf.Dto;
using SalesInvoiceExtPdf.Models;
using SalesInvoiceExtPdf.Services;
using System.Text.Json;

namespace SalesInvoiceExtPdf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesInvController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly InvAIService _invAIService;

        public SalesInvController(AppDbContext context, InvAIService invAIService)
        {
            _context = context;
            _invAIService = invAIService;
        }

        [HttpPost("extract")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Extract([FromForm] UploadReq request)
        {
            if (request.file == null || request.file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            PdfService pdfService = new();

            string extractedText =
                pdfService.ExtractText(
                    request.file.OpenReadStream());

            string json =
                await _invAIService.ExtractInvoiceAsync(extractedText);

            var invoice =
                JsonSerializer.Deserialize<SalesMaster>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return Ok(invoice);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SalesMaster model)
        {
            _context.SalesMaster.Add(model);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Invoice saved successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _context.SalesMaster.Include(x => x.Items).ToListAsync();

            return Ok(invoices);
        }
    }
}
