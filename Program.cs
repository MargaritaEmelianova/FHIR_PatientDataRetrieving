using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Linq;

namespace FHIR_PatientDataRetrieving
{
    internal class Program
    {

        static void Main(string[] args)
        {
           
            var settings = new FhirClientSettings
            {
                Timeout = 1000000,
                PreferredFormat = ResourceFormat.Json,
                VerifyFhirVersion = true,
            };

            Console.WriteLine("Venligst oppgi endepunkt: ");
            string url = Console.ReadLine();
            try
            {
                var client = new FhirClient(url, settings);


                Console.WriteLine("Vennligst oppgi kundenavn: ");
                string p_name = Console.ReadLine();





                var searchResult = client.Search("Patient", new string[] { "name=" + p_name });
                if (p_name != null)
                {
                    foreach (var result in searchResult.Entry)
                    {
                        var pat = (result.Resource as Patient);


                        try
                        {


                            Console.WriteLine(
                                $"Pasienten: {pat.Name[0].Given.FirstOrDefault()}  {pat.Name[0].Family} " +
                                $"{pat.Gender} {pat.BirthDate})");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message + "/n ");

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
