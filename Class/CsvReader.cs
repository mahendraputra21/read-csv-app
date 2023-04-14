using ReadCsvConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadCsvConsoleApp.Class
{
    public class CsvReader : ICsvReader
    {
        public List<Record> ReadCsv(string filePath)
        {
            List<Record> records = new List<Record>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header row
                string line = reader.ReadLine();
                string[] headers = line.Split(',');

                // Read the data rows
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Record record = new Record();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        switch (headers[i].Trim().ToLower())
                        {
                            case Constants.Field_Id:
                                record.Id = int.Parse(fields[i].Trim());
                                break;
                            case Constants.Field_Name:
                                record.Name = fields[i].Trim();
                                break;
                            case Constants.Field_Email:
                                record.Email = fields[i].Trim();
                                break;
                            case Constants.Field_Phone:
                                record.Phone = fields[i].Trim();
                                break;
                            case Constants.Field_Birthday:
                                record.Birthday = DateTime.Parse(fields[i].Trim());
                                break;
                            default:
                                // Ignore unknown headers
                                break;
                        }
                    }

                    records.Add(record);
                }
            }

            return records;
        }
    }
}
