
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Network.RestApi
{
    public class RestApi
    {
        public void Post(String url, String webContentType, String data) 
        {
            byte[] postDataByte = Encoding.UTF8.GetBytes(data);

            WebRequest request = WebRequest.Create(url);
            request.ContentType = webContentType;
            request.ContentLength = postDataByte.Length;
            request.Method = "POST";
            //request.GetResponse(); // GET 읽어오기

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(postDataByte, 0, postDataByte.Length);
            dataStream.Close();
        }
    }
}
