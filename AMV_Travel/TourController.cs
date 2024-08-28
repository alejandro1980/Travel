using AMV_Travel;
using AMV_Travel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly GestorReservasService _service;

    public TourController(GestorReservasService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AgregarTour(Tour tour)
    {
        _service.AgregarTour(tour);
        return Ok();
    }

    [HttpGet]
    public IActionResult MostrarTours()
    {
        var tours = _service.MostrarTours();
        return Ok(tours);
    }
}