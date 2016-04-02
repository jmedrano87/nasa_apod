﻿using System;
using System.Net;
using System.Reflection;

namespace ApodPcl
{
    static internal class Util
    {
        static public void SetHeader(HttpWebRequest request, string header, string value)
        {
            PropertyInfo propInfo = request.GetType().GetRuntimeProperty(header.Replace("-", string.Empty));

            if (propInfo != null)
                propInfo.SetValue(request, value, null);
            else
                request.Headers[header] = value;
        }
        static public HttpWebRequest CreateRequest(Uri url)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            SetHeader(req, "User-Agent", "nasa-apod-pcl/beta (.Net PCL)");

            return req;
        }
    }
}
