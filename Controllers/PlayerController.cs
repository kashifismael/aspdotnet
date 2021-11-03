using AspDotNetStarter.Exception;
using AspDotNetStarter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetStarter.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {

        private readonly ICrudService<Player> _playerService;

        public PlayerController(ICrudService<Player> playerService)
        {
            this._playerService = playerService;
        }

        [HttpGet]
        public List<Player> GetAllPlayers()
        {
            return _playerService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Player GetPlayerById(string id)
        {
            return _playerService.getOneById(id);
        }

        [HttpPost]
        public Player addPlayer(Player player)
        {
            validate(player, true);
            return _playerService.create(player);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updatePlayer(string id, Player player)
        {
            beforeUpdate(id);
            validate(player, false);
            _playerService.update(player);
            return Ok($"Player with id [{player.Id}] updated");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deletePlayer(string id)
        {
            _playerService.delete(id);
            return Ok($"Player with id [{id}] deleted");
        }

        private void beforeUpdate(string id)
        {
            Player player = _playerService.getOneById(id);
            if (player == null)
            {
                ValidationException ex = new ValidationException();
                ex.addMessage($"No record found for player with id [{id}]");
                throw ex;
            } 
        }

        private void validate(Player player, bool isCreate)
        {
            ValidationException ex = new ValidationException();
            if (isCreate && player.Id != null)
            {
                ex.addMessage("ID value is not valid on create");
            } else if (!isCreate && player.Id == null)
            {
                ex.addMessage("ID is required");
            }


            if (player.FirstName == null)
            {
                ex.addMessage("First name is required");
            }

            if (player.LastName == null)
            {
                ex.addMessage("Last name is required");
            }

            if (ex.Messages.Any())
            {
                ex.Status = 400;
                throw ex;
            }
        }

    }
}
