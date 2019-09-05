using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICoreModel model;
        private readonly IMapper mapper;

     
        private Expression<Func<Dic_Users, bool>> predicate = null;

        public UsersController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<List<User>> Get()
        {
            //Seteamos la tabla para obtener los registros.
            this.predicate = x => x.Id > 0;

            var entities =  await this.model.SearchAsync(this.predicate);
            List<User> listaUsers = new List<User>();

            //Se mapea el diccionario d ela base de datos al model structure
            listaUsers = this.mapper.Map<List<User>>(entities);
          

            return listaUsers;
        }

        /// <summary>
        /// Método para realizar la autorización de login
        /// </summary>
        /// <returns></returns>
        [HttpPost("Auth")]
        public async Task<ActionResult<User>> AutorizeUser(string email, string hashedpass) {

            this.predicate = x => x.Use_Email == email && x.Use_HashPassword == hashedpass;
            
            //Buscamos el usuario que cumpla las condiciones de logeo
            var entity = await this.model.GetOneAsync(this.predicate);

            //mapeamos el usuario
            var user = this.mapper.Map<User>(entity);

            if (user == null)
                return NotFound("Usuario no existe");

            return user;
        }

        // POST: api/Usuarios
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

   
    }
}
