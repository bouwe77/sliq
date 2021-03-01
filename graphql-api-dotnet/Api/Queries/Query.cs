using System.Linq;
using Api.Presentations;
using Api.Data;
using HotChocolate;
using System;

namespace Api.Queries
{
    public class Query
    {
        public IQueryable<PresentationModel> GetPresentations([Service] AppDbContext context)
        {
            var meuk = context.Presentations;
            return meuk;
        }

        public PresentationModel GetPresentation(int id, [Service] AppDbContext context)
        {
            try
            {
                var meuk = context.Presentations.Where(predicate => predicate.Id == id).SingleOrDefault();
                return meuk;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}