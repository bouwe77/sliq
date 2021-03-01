namespace Api.Presentations
{
    public class AddPresentationPayload
    {
        public AddPresentationPayload(PresentationModel presentation)
        {
            Presentation = presentation;
        }

        public PresentationModel Presentation { get; }
    }
}