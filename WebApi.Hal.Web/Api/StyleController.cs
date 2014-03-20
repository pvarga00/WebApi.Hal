using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Hal.Web.Api.Resources;
using WebApi.Hal.Web.Data;

namespace WebApi.Hal.Web.Api
{
    public class StyleController : ApiController
    {        
        readonly IBeerDbContext beerDbContext;

        public StyleController(IBeerDbContext beerDbContext)
        {
            this.beerDbContext = beerDbContext;
        }


        public HttpResponseMessage Get(int id)
        {
            var beerStyle = beerDbContext.Styles.SingleOrDefault(s => s.Id == id);
            if (beerStyle == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var beerStyleResource = new BeerStyleRepresentation
            {
                Id = beerStyle.Id,
                Name = beerStyle.Name
            };

            return Request.CreateResponse(HttpStatusCode.OK, beerStyleResource);
        }
    }
}
