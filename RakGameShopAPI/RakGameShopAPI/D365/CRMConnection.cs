using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;


namespace RakGameShopAPI.D365
{
    public class CRMConnection
    {
        public static CrmServiceClient CrmNewConnection()
        {
            var urlAmbiente = "https://org.crm2.dynamics.com/";
            var appID = "aaaa";
            var segredoAPP = "aaa";
            var connectionString = $"url={urlAmbiente};ClientId={appID};ClientSecret={segredoAPP};AuthType=ClientSecret";
            var service = new CrmServiceClient(connectionString);
            return service;
        }
    }
}


