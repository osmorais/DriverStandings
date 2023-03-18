using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Tests.Domain.Model
{
    public class RecordLogTest
    {
        [Fact]
        public void Test1_stringFileToRecordLogObject()
        {
            //Arrange 
            var fileString = "Hora;Piloto;Nº Volta;Tempo Volta;Velocidade média da volta \r\n" +
                "23:49:08.277;038 – F.MASSA;1;1:02.852;44,275 \r\n" +
                "23:49:10.858;033 – R.BARRICHELLO;1;1:04.352;43,243 \r\n" +
                "23:49:11.075;002 – K.RAIKKONEN;1;1:04.108;43,408 \r\n" +
                "23:49:12.667;023 – M.WEBBER;1;1:04.414;43,202 \r\n" +
                "23:49:30.976;015 – F.ALONSO;1;1:18.456;35,47 \r\n" +
                "23:50:11.447;038 – F.MASSA;2;1:03.170;44,053 \r\n" +
                "23:50:14.860;033 – R.BARRICHELLO;2;1:04.002;43,48 \r\n" +
                "23:50:15.057;002 – K.RAIKKONEN;2;1:03.982;43,493 \r\n" +
                "23:50:17.472;023 – M.WEBBER;2;1:04.805;42,941 \r\n" +
                "23:50:37.987;015 – F.ALONSO;2;1:07.011;41,528 \r\n" +
                "23:51:14.216;038 – F.MASSA;3;1:02.769;44,334 \r\n" +
                "23:51:18.576;033 – R.BARRICHELLO;3;1:03.716;43,675 \r\n" +
                "23:51:19.044;002 – K.RAIKKONEN;3;1:03.987;43,49 \r\n" +
                "23:51:21.759;023 – M.WEBBER;3;1:04.287;43,287 \r\n" +
                "23:51:46.691;015 – F.ALONSO;3;1:08.704;40,504 \r\n" +
                "23:52:01.796;011 – S.VETTEL;1;3:31.315;13,169 \r\n" +
                "23:52:17.003;038 – F.MASS;4;1:02.787;44,321 \r\n" +
                "23:52:22.586;033 – R.BARRICHELLO;4;1:04.010;43,474 \r\n" +
                "23:52:22.120;002 – K.RAIKKONEN;4;1:03.076;44,118 \r\n" +
                "23:52:25.975;023 – M.WEBBER;4;1:04.216;43,335 \r\n" +
                "23:53:06.741;015 – F.ALONSO;4;1:20.050;34,763 \r\n" +
                "23:53:39.660;011 – S.VETTEL;2;1:37.864;28,435 \r\n" +
                "23:54:57.757;011 – S.VETTEL;3;1:18.097;35,633 \r\n\"";

            //Act
            var result = new RecordLog().fileStringToRecordLogList(fileString);


            //Assert
            Assert.True(result != null && result.Count() > 0);
        }
    }
}
