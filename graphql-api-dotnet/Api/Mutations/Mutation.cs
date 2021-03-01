using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Presentations;
using HotChocolate;

namespace Api.Mutations
{
    public class Mutation
    {
        public async Task<AddPresentationPayload> AddPresentationAsync(
            AddPresentationInput input,
            [Service] AppDbContext context)
        {
            var presentation = new PresentationModel
            {
                Name = input.Name,
                Code = RandomCode.Get(),
                HasStarted = false,
                NumberOfSlides = 5,
                CurrentSlideIndex = 0
            };

            context.Presentations.Add(presentation);
            await context.SaveChangesAsync();

            return new AddPresentationPayload(presentation);
        }

        public async Task<StartOrEndPresentationPayload> StartPresentationAsync(
            StartOrEndPresentationInput input,
            [Service] AppDbContext context)
        {
            return await StartOrEndPresentation(input.Id, true, context);
        }

        public async Task<StartOrEndPresentationPayload> EndPresentationAsync(
            StartOrEndPresentationInput input,
            [Service] AppDbContext context)
        {
            return await StartOrEndPresentation(input.Id, false, context);
        }

        private async Task<StartOrEndPresentationPayload> StartOrEndPresentation(int id, bool hasStarted, AppDbContext context)
        {
            var presentation = context.Presentations.Where(predicate => predicate.Id == id).SingleOrDefault();

            if (presentation == null) return null;

            if (presentation.HasStarted != hasStarted)
            {
                presentation.HasStarted = hasStarted;
                context.Presentations.Update(presentation);
                await context.SaveChangesAsync();
            }

            return new StartOrEndPresentationPayload(presentation);
        }

        public async Task<ToSlidePayload> ToNextSlideAsync(
            ToSlideInput input,
            [Service] AppDbContext context)
        {
            return await GoToSlide(input.Id, true, context);
        }

        public async Task<ToSlidePayload> ToPreviousSlideAsync(
            ToSlideInput input,
            [Service] AppDbContext context)
        {
            return await GoToSlide(input.Id, false, context);
        }

        private async Task<ToSlidePayload> GoToSlide(int id, bool goToNext, AppDbContext context)
        {
            var presentation = context.Presentations.Where(predicate => predicate.Id == id).SingleOrDefault();

            if (presentation == null || !presentation.HasStarted) return null;

            var updatePresentation = true;
            if (goToNext && presentation.CurrentSlideIndex == presentation.NumberOfSlides - 1) updatePresentation = false;

            if (!goToNext && presentation.CurrentSlideIndex == 0) updatePresentation = false;

            if (updatePresentation)
            {
                presentation.CurrentSlideIndex = goToNext ? presentation.CurrentSlideIndex + 1 : presentation.CurrentSlideIndex - 1;
                context.Presentations.Update(presentation);
                await context.SaveChangesAsync();
            }

            return new ToSlidePayload(presentation);
        }

        public async Task<DeletePresentationPayload> DeletePresentationAsync(
            DeletePresentationInput input,
            [Service] AppDbContext context)
        {
            var presentation = new PresentationModel
            {
                Id = input.Id
            };

            context.Presentations.Remove(presentation);
            await context.SaveChangesAsync();

            return new DeletePresentationPayload(presentation);
        }
    }
}