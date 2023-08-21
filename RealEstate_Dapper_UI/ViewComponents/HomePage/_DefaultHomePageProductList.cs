using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        //Apinin Consume Edilmesi
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemci örneği oluşturduk

            var responseMessage = await client.GetAsync("http://localhost:5353/api/Product/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                //json bi değeri okuyo tablo(metin) formatına çeviriyor
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}
