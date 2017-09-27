using Mvc517.DAL;
using Mvc517.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mvc517.Website.Controllers
{
    public class RestApiController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<Opera>> Get()
        {
            using (var dbContext = new MvcDbContext())
            {
                return dbContext.Operas.ToList();
            }
        }


        [HttpPost]
        public async Task<HttpResponseMessage> Create(Opera viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


            using (var dbContext = new MvcDbContext())
            {
                viewModel.CreateOn = DateTime.Now;
                viewModel.UpdateOn = DateTime.Now;
                dbContext.Operas.Add(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Edit(Opera viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            using (var dbContext = new MvcDbContext())
            {
                viewModel.UpdateOn = DateTime.Now;
                dbContext.Entry(viewModel).State = System.Data.Entity.EntityState.Modified;

                await dbContext.SaveChangesAsync();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {

            using (var dbContext = new MvcDbContext())
            {
                var entity = dbContext.Operas.Where(x => x.Id.Equals(id)).FirstOrDefault();
                dbContext.Operas.Remove(entity);
                await dbContext.SaveChangesAsync();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
