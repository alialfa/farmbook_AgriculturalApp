using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using FarmBook_v7.Repositories;
using FarmBook_v7.Models;

/* The Community Contoller on the front-end of the site represents a core aggregation of the 
  * CHAT, STORIES, WEATHER features, however due to clarity concerns & module intergration
  * only the weather feature was called from this class
  * Please see the Chat & Stories controllers for their respective implementations
  */

namespace FarmBook_v7.Controllers
{
    public class CommunityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*
         * WEATHER SERVICE - The Weather method calls a getWeather method that is from an external service reference
         * that was obtained from donkerhoekdata.co.za/IWSWebServices/weather.asmx?op=getWeather 
         * The provider is an international weather provider & the method below has been customed to route to 
         * South African cities only & gives current weather updates ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
         * A SOAP client establishes the connection to a client objection via the SOAP configuration in the 
         * Web config file; when a city query is issued the results are captured in one "result" string and
         * string manipulation captures essentials which are passed to a ViewBag object to the Weather view
         */
        
        //[HttpPost]
        public ActionResult Weather(string CityName, string CountryName)
        {
            WeatherService.GlobalWeatherSoapClient client = new WeatherService.GlobalWeatherSoapClient("GlobalWeatherSoap");
                        
            string location, time, wind, visibility, skyconditions, temperature, dewpoint, humidity, pressure, status;

            if (!String.IsNullOrEmpty(CityName)) 
            {
                string result = client.GetWeather(CityName, "South Africa");

                location = getBetween(result,"<Location>","</Location>"); 
                time = getBetween(result,"<Time>","</Time>");
                wind = getBetween(result, "<Wind>", "</Wind>");
                visibility = getBetween(result, "<Visibility>", "</Visibility");
                skyconditions = getBetween(result, "<SkyConditions>", "</SkyConditions");
                temperature = getBetween(result, "<Temperature>", "</Temperature>");
                dewpoint = getBetween(result, "<DewPoint>", "</DewPoint>");
                humidity = getBetween(result, "<RelativeHumidity>", "</RelativeHumidity>");
                pressure = getBetween(result, "<Pressure>", "</Pressure>");
                status = getBetween(result, "<Status>", "</Status>");

                    if (status == "Success")
                    {
                        ViewBag.Error = string.Empty;
                        ViewBag.Location = location;
                        ViewBag.Time = time;
                        ViewBag.Wind = wind;
                        ViewBag.Visibility = visibility;
                        ViewBag.SkyConditions = skyconditions;
                        ViewBag.Temperature = temperature;
                        ViewBag.Dewpoint = dewpoint;
                        ViewBag.RelativeHumidity = humidity;
                        ViewBag.Pressure = pressure;
                        ViewBag.Status = status;
                    }
                    else
                    {
                        ViewBag.Error = "Sorry :( - Weather Retrival Failure - REFRESH & try again";
                        ViewBag.Location = string.Empty;
                        ViewBag.Time = string.Empty;
                        ViewBag.Wind = string.Empty;
                        ViewBag.Visibility = string.Empty;
                        ViewBag.SkyConditions = string.Empty;
                        ViewBag.Temperature = string.Empty;
                        ViewBag.Dewpoint = string.Empty;
                        ViewBag.RelativeHumidity = string.Empty;
                        ViewBag.Pressure = string.Empty;
                        ViewBag.Status = status;
                    } 
            }
            else {
                ViewBag.Coordinates = "Specify your city query update please...";
            }

            return View();
        }

        // method getBetween gets text between a string text
        public string getBetween(string Text, string FirstString, string LastString)
        {
            string STR = Text;
            string STRFirst = FirstString;
            string STRLast = LastString;
            string FinalString;

            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            int len = (Pos2 - Pos1);

            if (len > 0)
            {
                FinalString = STR.Substring(Pos1, len);
            }
            else
            {
                FinalString = "not_available";
            }
            return FinalString;
        }
        
        /// original weather method -- unformatted output
        /*
        public ActionResult Weather(string CityName, string CountryName)
        {
            WeatherService.GlobalWeatherSoapClient client = new WeatherService.GlobalWeatherSoapClient("GlobalWeatherSoap");

            if (!String.IsNullOrEmpty(CityName))
            {
                string result = client.GetWeather(CityName, "South Africa");

                ViewBag.WeatherUpdate = result;
                return View();
            }
            else
            {
                ViewBag.Coordinates = "Specify location please...";//"Sorry, Update Failed";
                return View();
            }
        }
        */
    }
}
