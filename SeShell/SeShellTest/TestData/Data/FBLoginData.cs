using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SeShell.Test.Core;
namespace SeShell.Test.TestData.Data
{
    public class FBLoginData :AbstractTestData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ExpectedResult { get; set; }
        public string ErrImage { get; set; }

        public static List<FBLoginData> GetLoginTestCases()
        {
            List<FBLoginData> testData = new List<FBLoginData>();
            string inputLine;
            using (FileStream inputStream =
                new FileStream(Configuration.TestDataFilePath + @"\FBLoginTestData.csv",
                    FileMode.Open,
                    FileAccess.Read))
            {
                StreamReader streamReader = new StreamReader(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(',');
                    testData.Add(new FBLoginData
                    {
                        UserName = Convert.ToString((data[0])),
                        Password = Convert.ToString((data[1])),
                        ExpectedResult = Convert.ToString(data[2]),
                        ErrImage = Convert.ToString(data[3]),
                        BrowserTypeEnum = int.Parse(data[4]),
                       
                    });
                }

                streamReader.Close();
                inputStream.Close();
            }

            return testData;
        }
        public override string[] GetClassPropertiesAsArray()
        {
            throw new NotImplementedException();
        }
    }
}
