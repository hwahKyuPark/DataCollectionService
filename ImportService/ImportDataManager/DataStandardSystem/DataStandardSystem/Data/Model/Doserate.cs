using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Data
{
    public class Doserate
    {
        private String apiOffer;
        private String apiKey;
        private String apiName;
        private DateTime apiOfferTime;
        private DateTime dbUpdateTime;
        private Double doserateValue;
        private String unit;

        public String ApiOffer
        {
            get { return apiOffer; }
            set { apiOffer = value; }
        }

        public String ApiKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        public String ApiName
        {
            get { return apiName; }
            set { apiName = value; }
        }

        public DateTime ApiOfferTime
        {
            get { return apiOfferTime; }
            set { apiOfferTime = value; }
        }

        public DateTime DbUpdateTime
        {
            get { return dbUpdateTime; }
            set { dbUpdateTime = value; }
        }

        public Double DoserateValue
        {
            get { return doserateValue; }
            set { doserateValue = value; }
        }

        public String Unit
        {
            get { return unit; }
            set { unit = value; }
        }
    }
}
