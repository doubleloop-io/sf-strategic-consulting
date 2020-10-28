namespace MruKata.Solutions
{
    public class TrackLastOpenFiles : IOpenEvents
    {
        const int Capacity = 10;
        readonly MruList solutionsAndProjects;
        readonly MruList files;

        public TrackLastOpenFiles()
        {
            solutionsAndProjects = new MruList(Capacity);
            files = new MruList(Capacity);
        }

        public void OnOpenSolution(string file) =>
            solutionsAndProjects.Track(file);

        public void OnOpenProject(string file) =>
            solutionsAndProjects.Track(file);

        public void OnOpenFile(string file) =>
            files.Track(file);
    }
}
