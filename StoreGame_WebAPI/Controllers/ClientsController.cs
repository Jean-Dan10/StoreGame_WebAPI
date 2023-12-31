﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.entities;

namespace StoreGame_WebAPI.Controllers
{
    [Route("api/GameStore/Clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly GameContext _context;

        public ClientsController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
          
          var clients = await _context.Clients.ToListAsync();

            if(clients.Count == 0) {
                return NotFound("Aucune données de clients");
            }

            return clients;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound("Aucun client avec le id suivant : "+ id);
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest("Le id ne concorde pas avec la requête");
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound("Aucun client avec le id suivant : " + id);
                }
                else
                {
                    throw;
                }
            }
                        
            var ClientMAJ = await _context.Clients.FindAsync(id);

            
            return Ok(new { Message = "Client mise-à-jour avec succès", Client = ClientMAJ });
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'GameContext.Clients'  is null.");
          }

        

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.IdClient }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound("Aucun client avec le id suivant : " + id);
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok("Le client avec le ID :" + id + " à été supprimé avec succès");
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
