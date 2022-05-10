using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class SubscriptionEntitlement : Resource 
    {
    
        public SubscriptionEntitlement() { }

        public SubscriptionEntitlement(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                JObj = JToken.Parse(reader.ReadToEnd());
                apiVersionCheck (JObj);
            }
        }

        public SubscriptionEntitlement(TextReader reader)
        {
            JObj = JToken.Parse(reader.ReadToEnd());
            apiVersionCheck (JObj);    
        }

        public SubscriptionEntitlement(String jsonString)
        {
            JObj = JToken.Parse(jsonString);
            apiVersionCheck (JObj);
        }

        #region Methods
     
        public static ListRequest EntitlementsForSubscription(string subscriptionId)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(subscriptionId), "subscription_entitlements");
            return new ListRequest(url);
        }
       
        #endregion

        #region Properties
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", true); }
        }

        public string FeatureId
        {
            get { return GetValue<string>("feature_id", true); }
        }

        public string FeatureName
        {
            get { return GetValue<string>("feature_name", true); }
        }

        public string StringValue
        {
            get { return GetValue<string>("value", true); }
        }

        public long LongValue
        {
            get { return GetValue<long>("value", true); }
        }

        public string Name
        {
            get { return GetValue<string>("name", true); }
        }
      

        #endregion

        #region Requests
       

        #endregion
    }
}
