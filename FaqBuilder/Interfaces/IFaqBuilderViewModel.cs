namespace FaqBuilder.Interfaces
{
    public interface IFaqBuilderViewModel
    {
        bool Success { get; set; }

        string Error { get; set; }
    }
}