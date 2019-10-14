﻿using System.Threading.Tasks;
using BNetInstaller.Constants;
using BNetInstaller.Models;
using Newtonsoft.Json.Linq;

namespace BNetInstaller.Endpoints.Version
{
    class VersionEndpoint : BaseEndpoint
    {
        public UidModel Model { get; }

        public ProductEndpoint Product { get; private set; }

        public VersionEndpoint(Requester requester) : base("version", requester)
        {
            Model = new UidModel();
        }

        public async Task<JToken> Get()
        {
            using (var response = await Requester.SendAsync(Endpoint + "/" + Model.Uid, HttpVerb.GET))
                return await Deserialize(response);
        }

        public async Task<JToken> Post()
        {
            using (var response = await Requester.SendAsync(Endpoint, HttpVerb.POST, Model))
                return await Deserialize(response);
        }
    }
}
