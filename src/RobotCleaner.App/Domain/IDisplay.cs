namespace RobotCleaner.App.Domain
{
    public interface IDisplay
    {
        string GetInput();
        void ShowOutput(string output);
    }
}