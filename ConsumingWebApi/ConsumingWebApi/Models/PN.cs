using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebApi.Models
{
    public class PN
    {

        https://www.youtube.com/watch?v=ItebhLqmJk8&list=PLuEZQoW9bRnSCZHlieeTk8Xji7JmaTCaq&index=47


        public String GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request) //Esa linea le esta pasando un objeto con el usuario y password, osea la credenciales
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(request); //Aqui yo le pasaria un objeto con el user y pass, para mandarlo por body y lo convierto a json
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                //Solo tengo que poner el .Result para eliminar el error
                //using (var cliente = new HttpClient())
                //{
                //    cliente.BaseAddress = new Uri("");
                //    var repuesta = cliente.PostAsync("", content).Result;
                //    var resultado = repuesta.Content.
                //}

                var url = $"{servicePrefix}{controller}";
                var response = client.PostAsync(url, content); //Le envio la url y el cuerpo
                var result = response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return result.ToString();
                    //return new Response
                    //{
                    //    IsSuccess = false,
                    //    Message = result,
                    //};
                }

                var token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        public string GetListAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller,
           string tokenType,
           string accessToken) //Este es el token
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };
                                                                                          // "Authorization", "Barear token"
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken); //Esta linea poner

                var url = $"{servicePrefix}{controller}";
                var response =  client.GetAsync(url); 
                var result = response.Content.ReadAsStringAsync();
                //El error desaparece si arriva le ponemos asycn y a las dos linea await

                if (!response.IsSuccessStatusCode)
                {
                    //Aqui guardamos en la db
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }



        /*Original to GetToken
         *  public async Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request)
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
         
         */
        /* USANDO EL TOKEN RECIBIDO ORIGINAL
         *  public async Task<Response> GetListAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller,
           string tokenType,
           string accessToken)
       {
           try
           {
               var client = new HttpClient
               {
                   BaseAddress = new Uri(urlBase),
               };

               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

               var url = $"{servicePrefix}{controller}";
               var response = await client.GetAsync(url);
               var result = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
               {
                   return new Response
                   {
                       IsSuccess = false,
                       Message = result,
                   };
               }

               var list = JsonConvert.DeserializeObject<List<T>>(result);
               return new Response
               {
                   IsSuccess = true,
                   Result = list
               };
           }
           catch (Exception ex)
           {
               return new Response
               {
                   IsSuccess = false,
                   Message = ex.Message
               };
           }
       }

        */
    }
}
