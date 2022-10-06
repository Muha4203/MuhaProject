using FootballPlayers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhaProject.Managers;

namespace MuhaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private FootballManager _manager = new FootballManager();

        // GET: api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll([FromQuery] string? nameFilter)
        {
            IEnumerable<FootballPlayer> playerList = _manager.GetAll(nameFilter);
            if (playerList.Count() == 0)
            {
                return NoContent();
            }
            return Ok(playerList);
        }
        [HttpGet]
        [Route("{id}")]
        public FootballPlayer? Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer newFootballPlayer)
        {
            try
            {
                FootballPlayer createdFootballPlayer = _manager.Add(newFootballPlayer);
                return Created("api/Footballplayer/" + createdFootballPlayer.Id, createdFootballPlayer);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public FootballPlayer? Put(int id, [FromBody] FootballPlayer updates)
        {
            return _manager.Update(id, updates);
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        public FootballPlayer? Delete(int id)
        {
            return _manager.Delete(id);
        }

    }
}
