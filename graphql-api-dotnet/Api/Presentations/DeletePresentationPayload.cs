namespace Api.Presentations
{
    public class DeletePresentationPayload
    {
        public DeletePresentationPayload(PresentationModel presentation)
        {
            Presentation = presentation;
        }

        public PresentationModel Presentation { get; }
    }
}