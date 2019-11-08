using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App1.Constant;
using App1.Entity;
using Newtonsoft.Json;

namespace App1.Service
{
    class MemberService : IMemberService
    {
        public Member Register(Member member)
        {
            try
            {
                var httpClient = new HttpClient();
                var dataToSend = JsonConvert.SerializeObject(member);
                var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(Api.MEMBER_REGISTER_URL, content).GetAwaiter().GetResult();
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                // ép kiểu kết quả từ dữ liệu json sang dữ liệu của C#
                var responseMember = JsonConvert.DeserializeObject<Member>(jsonContent);
                Debug.WriteLine(jsonContent);
                return responseMember;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public MemberCredential Login(LoginMember loginMember)
        {
            try
            {
                var httpClient = new HttpClient();
                var dataToSend = JsonConvert.SerializeObject(loginMember);
                var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(Api.MEMBER_LOGIN_URL, content).GetAwaiter().GetResult();
                var memberCredential = JsonConvert.DeserializeObject<MemberCredential>(response.Content.ReadAsStringAsync().Result);
                return memberCredential;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Member GetInformation(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            var response = httpClient.GetAsync(Api.MEMBER_GET_INFORMATION).GetAwaiter().GetResult();
            var member = JsonConvert.DeserializeObject<Member>(response.Content.ReadAsStringAsync().Result);
            return member;
        }
    }
}
