using System;

namespace P01._FileStream_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            File progressFile = new File(); //works with Music 
            progressFile.Sent = 50;
            progressFile.Length = 500;

            Progress progress = new Progress(progressFile);



        }
    }
}
