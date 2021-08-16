using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Introduction
{
    /// <summary>
    /// Attempt to solve the first example in the Linq course - the assignment was to implement
    /// a report that writes the fives largest files to the console of a given directory
    /// </summary>
    public class Me 
    {

        public void Run()
        {
            var dirInfo = new DirectoryInfo("C:\\Windows");
            var filesForArraySort = dirInfo.GetFiles();

            // sort using an implementation of IComparer
            Array.Sort(filesForArraySort, new FileComparer());

            PrintFiles<Array>(filesForArraySort);

            Console.WriteLine("------------------------------------");
            // sort using Linq
            var filesForLinqQuery = dirInfo.GetFiles();
            var filesSorted = filesForLinqQuery.OrderBy(f => f.Length).ToList();
            Console.WriteLine(filesForLinqQuery[0].Name);
            //PrintFiles<List<FileInfo>>(filesSorted);
        }
       /// <summary>
       /// Generic function to print files
       /// </summary>
       /// <typeparam name="T">A type paramenter that is enumarble</typeparam>
       /// <param name="files">The files that need to be printed </param>
       private void PrintFiles<T> (T files) where T : IEnumerable, IList
        {
            for(var i=0; i<5; i++)
            {
                Console.WriteLine($"{files[i]}");
            }
            
        }

        
    }

    /// <summary>
    /// A class that implements the Icomparer and can be used to compare on length prop of FileInfo
    /// </summary>
    public class FileComparer : IComparer <FileInfo>
    {
        /// <summary>
        /// The Compare method that implement IComparer - sorts in ascending
        /// </summary>
        /// <param name="info1"> fileinfo object </param>
        /// <param name="info2"> fileinfo object</param>
        /// <returns></returns>
        public int Compare(FileInfo info1, FileInfo info2)
        {
            if (info1.Length > info2.Length)
                return 1;
            if (info1.Length < info2.Length)
                return -1;
            return 0;
            // return info1.Length.CompareTo(info2.Length);
        }
    }

}
