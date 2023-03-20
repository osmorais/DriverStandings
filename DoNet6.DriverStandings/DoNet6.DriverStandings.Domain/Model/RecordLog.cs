using DotNet6.DriverStandings.Domain.Validations;
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

            if (fileLines.Count() <= 2)
                throw new DomainValidationException("Arquivo fora da formatação esperada.");

            var records = new List<RecordLog>();

            try
            {
                foreach (string line in fileLines)
                {
                    if (line == fileLines[0] || line.Length <= 2)
                        continue;

                    string[] fields = line.Split(';');

                    if (fields.Count() < 5)
                        throw new DomainValidationException("Linha do arquivo sem todos os campos necessarios.");

                    var record = new RecordLog()
                    {
                        Time = TimeSpan.Parse(fields[0]),
                        DriverCode = fields[1].Split("–")[0].Trim(),
                        DriverName = fields[1].Split("–")[1].Trim(),
                        LapNumber = int.Parse(fields[2]),
                        LapTime = TimeSpan.Parse($"00:{fields[3]}"),
                        AverageSpeed = double.Parse(fields[4])
                    };

                    this.Validation(record);

                    records.Add(record);
                }
            }
            catch (DomainValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new DomainValidationException(string.Format("Erro ao converter o arquivo de upload. -- Message: {0}", ex.Message));
            }

            return records;
        }

        public void Validation(RecordLog recordLog)
        {
            DomainValidationException.When(string.IsNullOrEmpty(recordLog.DriverCode), "Codigo do piloto vazio.");
            DomainValidationException.When(Domain.Util.Utils.hasSpecialCharacters(recordLog.DriverName), "Nome do piloto contem caracteres especiais.");
            DomainValidationException.When(Domain.Util.Utils.hasNumber(recordLog.DriverName), "Nome do piloto contem numero.");
        }
    }
}
