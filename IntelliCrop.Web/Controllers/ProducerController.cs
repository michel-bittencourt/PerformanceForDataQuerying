using IntelliCrop.Application.Interfaces;
using IntelliCrop.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntelliCrop.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProducerController : ControllerBase
{
    #region Properties
    private readonly IProducerService _producerService;
    #endregion

    #region Constructor
    public ProducerController(IProducerService producerService)
    {
        _producerService = producerService;
    }
    #endregion

    #region Metodos
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Producer producer)
    {
        if (producer != null)
        {
            await _producerService.Add(producer);
            return Created($"/producer/{producer.Id}", producer);
        }
        return BadRequest();
    }

    [HttpGet("EF")]
    public async Task<IActionResult> GetByIdEF(Guid? id)
    {
        if (id != null)
        {
            var stopwatch = Stopwatch.StartNew();

            Producer producer = await _producerService.GetProducerByIdAsyncEF(id);

            stopwatch.Stop();

            TimeSpan elapsed = stopwatch.Elapsed;

            Console.WriteLine("============================================");
            Console.WriteLine($"GetByIdEF method executed in {elapsed.TotalMilliseconds} milliseconds.");
            Console.WriteLine("============================================");

            return Ok(producer);
        }
        return BadRequest();
    }

    [HttpGet("SQL")]
    public async Task<IActionResult> GetByIdSQL(Guid? id)
    {
        if (id != null)
        {
            var stopwatch = Stopwatch.StartNew();

            Producer producer = await _producerService.GetProducerByIdAsyncSQL(id);

            stopwatch.Stop();

            TimeSpan elapsed = stopwatch.Elapsed;

            Console.WriteLine("============================================");
            Console.WriteLine($"GetByIdSQL method executed in {elapsed.TotalMilliseconds} milliseconds.");
            Console.WriteLine("============================================");

            return Ok(producer);
        }
        return BadRequest();
    }

    [HttpGet("DAPPER")]
    public async Task<IActionResult> GetByIdDAPPER(Guid? id)
    {
        if (id != null)
        {
            var stopwatch = Stopwatch.StartNew();

            Producer producer = await _producerService.GetProducerByIdAsyncDAPPER(id);

            stopwatch.Stop();

            TimeSpan elapsed = stopwatch.Elapsed;

            Console.WriteLine("============================================");
            Console.WriteLine($"GetByIdDAPPER method executed in {elapsed.TotalMilliseconds} milliseconds.");
            Console.WriteLine("============================================");

            return Ok(producer);
        }
        return BadRequest();
    }
    #endregion
}
