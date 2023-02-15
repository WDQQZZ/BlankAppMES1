using ICSharpCode.SharpZipLib.GZip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Common
{
    public class HttpRequest
    {
        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="https://localhost:44329/swagger/index.html">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsyncJson(string url, string json)
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            Console.WriteLine(responseBody);
            return responseBody;
        }

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数字符串</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsync(string url, string data, Dictionary<string, string> header = null, bool Gzip = false)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpContent content = new StringContent(data);
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = "";
            if (Gzip)
            {
                GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                responseBody = new StreamReader(inputStream).ReadToEnd();
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();

            }
            return responseBody;
        }

        /// <summary>
        /// 使用get方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string> header = null, bool Gzip = false)
        {

            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();//用来抛异常的
            string responseBody = "";
            if (Gzip)
            {
                GZipInputStream inputStream = new GZipInputStream(await response.Content.ReadAsStreamAsync());
                responseBody = new StreamReader(inputStream).ReadToEnd();
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();

            }
            return responseBody;
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> PostObjectAsync<T, T2>(string url, T2 obj)
        {
            String json = JsonConvert.SerializeObject(obj);
            string responseBody = await PostAsyncJson(url, json); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

        /// <summary>
        /// 使用Get返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <returns>返回请求的对象</returns>
        public static async Task<T> GetObjectAsync<T>(string url)
        {
            string responseBody = await GetAsync(url); //请求当前账户的信息
            return JsonConvert.DeserializeObject<T>(responseBody);//把收到的字符串序列化
        }

        //生成HttpHelper帮助类用于请求后台接口
        public static class HttpHelper
        {
            public static string Get(string url)
            {
                //请求后台接口
                var result = HttpHelper.HttpGet(url);
                //返回结果
                return result;
            }

            public static string HttpGet(string url)
            {
                //解释：HttpWebRequest是一个抽象类，它的派生类有HttpWebRequest和FtpWebRequest，HttpWebRequest类用于发出HTTP请求，FtpWebRequest类用于发出FTP请求。
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//创建一个请求示例
                request.Method = "GET";//请求方式，request.Method有很多种，如GET、POST、PUT、DELETE等
                request.ContentType = "text/html;charset=UTF-8";//解释：请求的内容类型，如text/html、text/plain、application/json、application/x-www-form-urlencoded等
                //HttpWebResponse是一个抽象类，它的派生类有HttpWebResponse和FtpWebResponse，HttpWebResponse类用于处理HTTP响应，FtpWebResponse类用于处理FTP响应。
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();//获取响应，
                Stream myResponseStream = response.GetResponseStream();//获取响应流
                //解释：StreamReader是用来读取字符流的，它的构造函数有很多，
                //如：StreamReader(Stream stream)、StreamReader(Stream stream, Encoding encoding)、
                //StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)、
                //StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)、
                //StreamReader(string path)、StreamReader(string path, Encoding encoding)、
                //StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)、
                //StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)等
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                //解释：ReadToEnd()方法用于从当前流中读取所有字符，并将数据作为一个字符串返回。
                string retString = myStreamReader.ReadToEnd();//读取所有
                myStreamReader.Close();//关闭读取流
                myResponseStream.Close();//解释：关闭当前流并释放与之关联的所有资源（如套接字和文件句柄）
                return retString;
                
            }
            //查询
            public static string NewGet(string Url)
            {
                HttpClient client = new HttpClient();
                var value = client.GetStringAsync(Url).Result;
                return value;
            }

            /// <summary>
            /// Post请求
            /// </summary>
            /// <param name="url">请求的url地址</param>
            /// <param name="data">请求的数据</param>
            /// <param name="contentType">请求的数据格式</param>
            /// <returns></returns>
            public static string Post(string url, string data, string contentType)
            {
                string result = string.Empty;
                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = contentType;
                    request.ContentLength = bytes.Length;
                    Stream stream = request.GetRequestStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    result = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }

             
            ///生成HttpHelper帮助类用于请求后台Delete接口带条件查询
            public static string NewDelete(string Url, string name, string value)
            {
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    { name, value }
                };
                var content = new FormUrlEncodedContent(values);
                var response = client.DeleteAsync(Url);
                var responseString = response.Result.Content.ReadAsStringAsync();
                return responseString.Result;
            }
            //生成HttpHelper帮助类用于请求后台Put接口带条件查询
            public static string NewPut(string Url, string name, string value)
            {
                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                    { name, value }
                };
                var content = new FormUrlEncodedContent(values);
                var response = client.PutAsync(Url, content);
                var responseString = response.Result.Content.ReadAsStringAsync();
                return responseString.Result;
            }

        }

    }
}
