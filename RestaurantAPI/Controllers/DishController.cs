using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("/api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"/api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dishDto = _dishService.GetById(restaurantId, dishId);

            return Ok(dishDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var dishesDto = _dishService.GetAll(restaurantId);

            return Ok(dishesDto);
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteById([FromRoute]int restaurantId, [FromRoute]int dishId)
        {
            _dishService.RemoveById(restaurantId, dishId);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute]int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);

            return NoContent();
        }
    }
}