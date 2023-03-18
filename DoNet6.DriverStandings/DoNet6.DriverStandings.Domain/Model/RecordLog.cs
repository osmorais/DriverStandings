using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.Model
{
    public class RecordLog
    {
        public TimeSpan Time { get; set; }
        public string DriverName { get; set; }
        public string DriverCode { get; set; }
        public int LapNumber { get; set; }
        public TimeSpan LapTime { get; set; }
        public double AverageSpeed { get; set; }

        public List<RecordLog> fileStringToRecordLogList(string fileString)
        {
            string[] fileLines = fileString.Split('\n');

            var records = new List<RecordLog>();

            foreach (string line in fileLines)
            {
                if (line == fileLines[0] || line.Length <= 2)
                    continue;

                string[] fields = line.Split(';');

                var record = new RecordLog()
                {
                    Time = TimeSpan.Parse(fields[0]),
                    DriverCode = fields[1].Split("–")[0].Trim(),
                    DriverName = fields[1].Split("–")[1].Trim(),
                    LapNumber = int.Parse(fields[2]),
                    LapTime = TimeSpan.Parse($"00:{fields[3]}"),
                    AverageSpeed = double.Parse(fields[4])
                };

                records.Add(record);
            }

            return records;
        }
    }
}
