﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeArePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeArePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5353/api/WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("http://localhost:5353/api/Service");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();

                return View(value2);
            }
            return View();
        }
    }
}
