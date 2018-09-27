using Aerospike.Client;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSpikeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Gurbaksh";
                int coulmnFlag = 0;
                using (TextFieldParser parser = new TextFieldParser(@"c:\accounts.csv"))
                {
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        if(coulmnFlag==0)
                        {
                            parser.ReadFields();
                            coulmnFlag = 1;
                            continue;
                        }
                        string[] fields = parser.ReadFields();
                            var key = new Key(nameSpace, setName, fields[13]);
                            aerospikeClient.Put(new WritePolicy(), key, new Bin[] { new Bin("description", fields[0]), new Bin("statusesCount", fields[1]), new Bin("followersCount", fields[2]), new Bin("favoritesCount", fields[3]), new Bin("friendsCount", fields[4]), new Bin("url", fields[5]), new Bin("name", fields[6]), new Bin("created", fields[7]), new Bin("protected", fields[8]), new Bin("verified", fields[9]), new Bin("screenName", fields[10]), new Bin("location", fields[11]), new Bin("lang", fields[12]), new Bin("id", fields[13]), new Bin("listedCount", fields[14]), new Bin("followSent", fields[15]), new Bin("profileImage", fields[16]), new Bin("rank", fields[17]) });
                        
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                throw;
            }
        }
    }
}
