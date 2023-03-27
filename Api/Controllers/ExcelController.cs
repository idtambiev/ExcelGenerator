using Api.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _service;
        private readonly ExcelOptions _excelOptions;
        public ExcelController(IExcelService service, IOptions<ExcelOptions> excelOptions)
        {
            _service = service;
            _excelOptions = excelOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcelFile()
        {
            var fileBytes = await _service.GenerateExcelFile();

            var fileName = _excelOptions.FileName;
            var contentType = _excelOptions.ContentType;

            return File(fileBytes, contentType, fileName);
        }
    }
}
