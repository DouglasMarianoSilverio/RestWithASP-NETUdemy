using System.IO;

namespace RestWithASPNETUdemy.Business.Implementation
{
    public class FileBusiness : IFileBusiness
    {
        
        

        public FileBusiness()
        {
        }

        public byte[] GetPdfFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + "\\Other\\sample.pdf";
            return File.ReadAllBytes(fullPath); ;
        }
    }
}
