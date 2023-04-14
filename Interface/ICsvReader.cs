using ReadCsvConsoleApp.Class;
using System.Collections.Generic;

namespace ReadCsvConsoleApp.Interface
{
    public interface ICsvReader
    {
        List<Record> ReadCsv(string filePath);
    }
}
