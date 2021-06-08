using System;
using System.IO;
using System.Reflection;

namespace PairProgramming.Common.Helpers
{
    public static class AssemblyInfo
    {
        public static DateTime GetBuildDateTime()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileInfo = new FileInfo(assembly.Location);
            var lastModified = fileInfo.LastWriteTime;
            return lastModified;
        }
    }
}
