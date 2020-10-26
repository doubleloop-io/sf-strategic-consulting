namespace MruKata
{
    public interface IOpenEvents
    {
        void OnOpenSolution(string file);
        void OnOpenProject(string file);
        void OnOpenFile(string file);
    }
}