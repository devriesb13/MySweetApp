namespace MySweetApp.Core.Contracts
{
    public interface ISelectionType
    {
        string Name { get; }

        IResult Find();
    }
}