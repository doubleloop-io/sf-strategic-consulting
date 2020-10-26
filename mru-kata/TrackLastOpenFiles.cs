using System;
using System.Collections.Generic;

namespace MruKata
{
    public class TrackLastOpenFiles : IOpenEvents
    {
        readonly List<string> solutionsAndProjects;
        readonly List<string> files;

        public TrackLastOpenFiles()
        {
            solutionsAndProjects = new List<string>();
            files = new List<string>();
        }

        public void OnOpenSolution(string file)
        {
            if (file == null) throw new ArgumentNullException();

            if (solutionsAndProjects.Contains(file))
                solutionsAndProjects.Remove(file);

            solutionsAndProjects.Add(file);

            if (solutionsAndProjects.Count > 10)
                files.RemoveAt(10 - 1);
        }

        public void OnOpenProject(string file)
        {
            if (file == null) throw new ArgumentNullException();

            if (solutionsAndProjects.Contains(file))
                solutionsAndProjects.Remove(file);

            solutionsAndProjects.Add(file);

            if (solutionsAndProjects.Count > 10)
                solutionsAndProjects.RemoveAt(10 - 1);
        }

        public void OnOpenFile(string file)
        {
            if (file == null) throw new ArgumentNullException();

            if (files.Contains(file))
                files.Remove(file);

            files.Add(file);

            if (files.Count > 10)
                files.RemoveAt(10 - 1);
        }
    }
}
