using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LawDepotAssessment.Utils
{
	public class JsonReader
	{
  

        public String ExtractData(String token)
        {
            String LocalDrirectory = Environment.CurrentDirectory;
            String ProjDirect = Directory.GetParent(LocalDrirectory).Parent.Parent.FullName;

            String myString = File.ReadAllText(ProjDirect+"\\testData.json");
            var jsonObject = JToken.Parse(myString);
            return jsonObject.SelectToken(token).Value<String>();

        }

    }
}

