using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;
using WebApiCore.Helpers.Messages;

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

            var entities =  await this.model.GetAllAsync<Dic_Users>().ToListAsync();


            List<User> listaUsers = new List<User>();

            //Se mapea el diccionario d ela base de datos al model structure
            listaUsers = this.mapper.Map<List<User>>(entities);
          

            return listaUsers;
        }


        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {

            var entity = await this.model.GetOneAsync<Dic_Users>(x => x.Id == id);


            //Se mapea el diccionario d ela base de datos al model structure
            var user = this.mapper.Map<User>(entity);


            return user;
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
        public async Task<ActionResult<bool>> Post([FromBody] User data)
        {
            //Comprobamos si ya existe algún usuario con ese email:
            this.predicate = x => x.Use_Email == data.Email;

            var compround = await this.model.GetOneAsync(this.predicate);

            if (compround != null)
                return false;

            //Mapeamos el structure model al diccionario
            // var entity = this.mapper.Map<Dic_Users>(data);
            //Mapeo temporal, => error en mapper

            //Generamos un número de dinero aleatorio
            Random rnd = new Random();
            var randomMoney = rnd.Next(4000000, 16000000);

            var entity = new Dic_Users() {
                Id = data.Id,
                Rol = null,
                Use_Address= data.Address,
                Use_Email = data.Email,
                Use_FirstName = data.FirstName,
                Use_HashPassword = data.HashPassword,
                Use_LastName = data.LastName,
                Use_CreationDate = DateTime.Now,
                Use_Money = randomMoney,
                Use_Phone = data.Phone,
                Use_RolIdFk = data.Rol,
                Use_Status = data.Status
            };

            //Creamos la entidad en la base de datos.
            var result = await this.model.AddAsync(entity);

            return result;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] User data)
        {
            if (id != data.Id)
                return BadRequest(Errors.INCORRECTDATA);

            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            entity.Rol = null;

            //Actualizamos los datos básicos
            entity.Use_FirstName = data.FirstName;
            entity.Use_LastName = data.LastName;
            entity.Use_Phone = data.Phone;
            entity.Use_RolIdFk = data.Rol;

            return await this.model.UpdateAsync(entity);

        }


   
        // PUT: api/Usuarios/5
        [HttpPut("ChangeStatus")]
        public async Task<ActionResult<bool>> ChangeStatus(int id)
        {

            this.predicate = x => x.Id == id;

            //Obtenemos la entidad a actualizar
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return NotFound(Errors.ENTITYNOTFOUND);

            //Cambiamos el estado
            entity.Use_Status = !entity.Use_Status;

            //Hacemos la actualización
            return await this.model.UpdateAsync(entity);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            //Creamos el predicado
            this.predicate = x => x.Id == id;

            //Comprobamos que existe una entidad con ese Id
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);            

            //Eliminamos la Categoria
            return await this.model.DeleteAsync(entity);
        }

   
   
    }
}
