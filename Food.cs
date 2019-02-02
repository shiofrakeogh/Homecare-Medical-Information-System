using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace HMIS
{
    public class Food
    {
        string foodID;
        string breakfast;
        string lunch;
        string dinner;
        string snacks;

        [JsonProperty(PropertyName = "foodID")]
        public string foodid
        {
            get { return foodID; }
            set { foodID = value; }
        }

        [JsonProperty(PropertyName = "breakfast")]
        public string breakFast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }

        [JsonProperty(PropertyName = "lunch")]
        public string lunch1
        {
            get { return lunch; }
            set { lunch = value; }
        }

        [JsonProperty(PropertyName = "dinner")]
        public string dinner1
        {
            get { return dinner; }
            set { dinner = value; }
        }

        [JsonProperty(PropertyName = "snacks")]
        public string snacks1
        {
            get { return snacks; }
            set { snacks = value; }
        }


        [Version]
        public string Version { get; set; }
    }
}
