using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
	public class BaseApi : ControllerBase
	{
		private readonly IHttpClientFactory _httpClient;
		public BaseApi(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> PostToApi(string ControllerMethodUrl, object model, string token)
		{
			try
			{
				var client = _httpClient.CreateClient("useApi");

				if(token != "")
				{
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

                }

				var response = await client.PostAsJsonAsync(ControllerMethodUrl, model);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					return Ok(content);
				}
				return BadRequest(response);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        public async Task<IActionResult> GetToApi(string ControllerMethodUrl, string token)
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                if (token != "")
				{
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

                }

                var response = await client.GetAsync(ControllerMethodUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
