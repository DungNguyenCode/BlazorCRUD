using AppData.Interface;
using AppData.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Xml.Linq;

namespace AppView.Services
{
    public class APIService : IAPIService
    {
        private readonly HttpClient _httpClient;

        public APIService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Userr> AddUser(Userr userr)
        {
            var result = await _httpClient.PostAsJsonAsync<Userr>("/User/Post", userr);
            result.EnsureSuccessStatusCode(); // Đảm bảo yêu cầu POST thành công

            var addedUser = await result.Content.ReadFromJsonAsync<Userr>();
            return addedUser;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/User/Delete/{id}");
            var i = result.EnsureSuccessStatusCode();
            if (i != null)
            {
                return false;
            }
            return true;


        }

        public async Task<Userr> GetSingleUser(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Userr>($"/User/GetById/{id}");
            if (result != null)
            {
                return result;
            }


            throw new Exception(" User not Found!");
        }

        public async Task<List<Userr>> GetUserrs()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Userr>>("/User/GetAll");
            return result;
        }

        public async Task<Userr> UpdateUser( Userr userr)
        {
            var response = await _httpClient.PutAsJsonAsync<Userr>($"/User/Put/{userr.Id}", userr);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Userr>();
            return result;
        }

      
    }
}
