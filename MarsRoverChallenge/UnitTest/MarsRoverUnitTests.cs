using System;
using MarsRoverChallenge.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using MarsRoverChallenge.Classes;

namespace MarsRoverChallenge.UnitTests
{
    public class MarsRoverUnitTests
    {
        
        public static string PlotRoversOnPlateauUrl = "https://localhost:44348/api/MarsRover/PlotRoversOnPlateau";

        [Fact]
        public void MarsRoverChallenge_CorrectData()
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);   
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(PlotRoversOnPlateauUrl);


            List<string> reqString = new List<string>();
            reqString.Add("5 5");
            reqString.Add("1 2 N");
            reqString.Add("LMLMLMLMM");
            reqString.Add("3 3 E");
            reqString.Add("MMRMMRMRRM");

            var request = JsonConvert.SerializeObject(reqString);
            restRequest.AddJsonBody(reqString);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK && restResponse.Content == "[\"1 3 N\",\"5 1 E\"]" )
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false,"Rover Correct Test Data failed");
            }
        }


        [Fact]
        public void MarsRoverChallenge_RoverOutOfBounds()
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(PlotRoversOnPlateauUrl);


            List<string> reqString = new List<string>();
            reqString.Add("5 5");
            reqString.Add("1 2 N");
            reqString.Add("MMMMMMMMMMM");
            reqString.Add("3 3 E");
            reqString.Add("MMRMMRMRRM");

            var request = JsonConvert.SerializeObject(reqString);
            restRequest.AddJsonBody(reqString);

            restResponse = restClient.Execute(restRequest);
            string restContent = JsonConvert.DeserializeObject(restResponse.Content).ToString();
            if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest && restContent == ExceptionMessages.RoverExitPlateauError)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false, "Rover Out of bounds test failed");
            }
        }


        [Fact]
        public void MarsRoverChallenge_RoverCrash()
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(PlotRoversOnPlateauUrl);


            List<string> reqString = new List<string>();
            reqString.Add("5 5");
            reqString.Add("1 2 N");
            reqString.Add("M");
            reqString.Add("1 2 N");
            reqString.Add("MM");

            var request = JsonConvert.SerializeObject(reqString);
            restRequest.AddJsonBody(reqString);

            restResponse = restClient.Execute(restRequest);
            string restContent = JsonConvert.DeserializeObject(restResponse.Content).ToString();
            if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest && restContent == ExceptionMessages.RoverCrashError)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false, "Rover Crash test Failed");
            }
        }
    }
}
