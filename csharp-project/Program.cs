 using System;
 using System.Linq;
 using Cassandra;

 namespace astraconnect
 {
     class Program
     {
         static void Main(string[] args)
         {
             var session =
                 Cluster.Builder()
                        .WithCloudSecureConnectionBundle(@"C:\personal\data-stax-astra-test\secure-connect-db-test.zip")
                        //or if on linux .WithCloudSecureConnectionBundle(@"/PATH/TO/>>secure-connect-db-test.zip")
                        .WithCredentials("zutjmx", "Proxmox5")
                        .Build()
                        .Connect();

             var rowSet = session.Execute("select * from system.local");
             Console.WriteLine("El valor de key es: " + rowSet.First().GetValue<string>("key"));

         }
     }
 }
