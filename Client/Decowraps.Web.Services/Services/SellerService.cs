
using Decowraps.Web.Services.DTOs;
using Decowraps.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Decowraps.Web.Services.Services
{
    public class SellerService : ISellerService
    {
        private readonly string _path = "https://localhost:7033/api/Seller";
        private static HttpClient _client = new HttpClient();
        private JsonSerializerOptions _jsonSerializerOptions;

        public SellerService() 
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<bool> CreateSeller(SellerDTO seller)
        {
            var result = false;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new(JsonSerializer.Serialize<SellerDTO>(seller), Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(_path, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = response.IsSuccessStatusCode;
            }
            return result;
        }

        public async Task<bool> DeleteSeller(int sellerId)
        {
            string deletePath = $"{_path}/{sellerId}";
            HttpResponseMessage response = await _client.DeleteAsync(deletePath);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public async Task<IEnumerable<SellerDTO>> GetAllSellers()
        {
            HttpResponseMessage response = await _client.GetAsync(_path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sellers = JsonSerializer.Deserialize<List<SellerDTO>>(content, _jsonSerializerOptions);
                return sellers;
            }
            return null;
        }

        public async Task<SellerDTO> GetSellerById(int sellerId)
        {
            string getPath = $"{_path}/{sellerId}";
            HttpResponseMessage response = await _client.GetAsync(getPath);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var seller = JsonSerializer.Deserialize<SellerDTO>(content, _jsonSerializerOptions);
                return seller;
            }
            return null;
        }

        public async Task<bool> UpdateSeller(SellerDTO seller)
        {
            var result = false;
            string updatePath = $"{_path}/{seller.sellerId}";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new(JsonSerializer.Serialize<SellerDTO>(seller), Encoding.UTF8, "application/json");
                using var response = await httpClient.PutAsync(updatePath, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = response.IsSuccessStatusCode;
            }
            return result;
        }
    }
}
