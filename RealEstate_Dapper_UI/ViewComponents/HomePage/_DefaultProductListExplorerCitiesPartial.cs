using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopulerLocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProductListExplorerCitiesPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _DefaultProductListExplorerCitiesPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClient.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5353/api/PopulerLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultPopulerLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
