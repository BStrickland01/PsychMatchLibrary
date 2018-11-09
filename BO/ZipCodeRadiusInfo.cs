using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.BO
{
    public class ZipCodesByRadius_Min
    {
        [JsonProperty("zip_codes")]
        public List<int> ZipCodes { get; set; }
    }

    public class ZipCodesByRadius_All
    {
        [JsonProperty("zip_codes")]
        public List<ZipCodeInfo> ZipCodes { get; set; }
    }

    public class ZipCodeInfo
    {
        [JsonProperty("zip_code")]
        public int ZipCode { get; set; }
        public decimal Distance { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class LocationInfo
    {
        [JsonProperty("zip_code")]
        public int ZipCode { get; set; }
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
        [JsonProperty("lng")]
        public decimal Longitude { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [JsonProperty("timezone")]
        public TZoneInfo TimezoneInfo { get; set; }
        [JsonProperty("acceptable_city_names")]
        public List<Abbreviations> Abbreviations { get; set; }
    }

    public class Abbreviations
    {
        public string City { get; set; }
        public string State { get; set; }
    }

    public class TZoneInfo
    {
        [JsonProperty("timezone_identifier")]
        public string TimeZoneIdentifier { get; set; }
        [JsonProperty("timezone_abbr")]
        public string TimeZoneAbbr { get; set; }
        [JsonProperty("utc_offset_sec")]
        public int UtcOffsetSec { get; set; }
        [JsonProperty("is_dst")]
        public string IsDST { get; set; }
    }

}
