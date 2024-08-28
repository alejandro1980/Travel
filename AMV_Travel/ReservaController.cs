using AMV_Travel.Entities;
using AMV_Travel;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly GestorReservasService _service;

    public ReservaController(GestorReservasService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult ReservarTour(Reserva reserva)
    {
        _service.ReservarTour(reserva);
        return Ok();
    }

    [HttpGet]
    public IActionResult MostrarReservas()
    {
        var reservas = _service.MostrarReservas();
        return Ok(reservas);
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarReserva(int id)
    {
        _service.EliminarReserva(id);
        return Ok();
    }
}