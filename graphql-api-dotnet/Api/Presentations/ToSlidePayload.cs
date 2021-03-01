namespace Api.Presentations
{
    public class ToSlidePayload
    {
        public ToSlidePayload(PresentationModel presentation)
        {
            Presentation = presentation;
        }

        public PresentationModel Presentation { get; }
    }
}