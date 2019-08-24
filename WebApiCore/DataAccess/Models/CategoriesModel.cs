using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Entities;

namespace WebApiCore.DataAccess.Models
{
    public class CategoriesModel : CoreModel
    {
        public CategoriesModel(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CreateAsync(Dic_Categories entity){

            base.AddAsync<Dic_Categories>(entity);

            return await base.SaveAsync();
        }


    }
}
