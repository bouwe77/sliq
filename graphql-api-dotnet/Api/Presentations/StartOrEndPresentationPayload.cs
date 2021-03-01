namespace Api.Presentations
{
    public class StartOrEndPresentationPayload
    {
        public StartOrEndPresentationPayload(PresentationModel presentation)
        {
            Presentation = presentation;
        }

        public PresentationModel Presentation { get; }
    }
}