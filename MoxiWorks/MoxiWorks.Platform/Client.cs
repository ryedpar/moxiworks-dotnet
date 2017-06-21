﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
namespace MoxiWorks.Platform
{
    public static class Client 
    {
        private static HttpClient _context = null;
        public static HttpClient Context
        {
            get
            {
                if (_context == null )
                {
                    _context = getContext(); 
                }
                return _context;
            }
        }


        private static CookieContainer  _cookies = null;
        public static CookieContainer Cookies {
            get {
                if (_cookies == null )
                {
                    _cookies = new CookieContainer(); 
                }
                return _cookies;
            }
        }

        public static void ResetClient()
        {
            _context = getContext(); 
        }


        private static HttpClientHandler _handler = null;
        private static HttpClient getContext()
        {
            _handler = new HttpClientHandler();
            _handler.CookieContainer = Cookies;
            _handler.UseCookies = true; 
            return new HttpClient(_handler);
        } 

 

        //public Credentials Cred {
        //    get { return new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt"); }
        //}

        //public Client()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress "https://api-qa.moxiworks.com"
        //    var auth = new AuthenticationHeaderValue("Basic " + Cred.ToBase64());
        //    client.DefaultRequestHeaders.Authorization = auth;
        //    client.DefaultRequestHeaders.Add("Accept", "application / vnd.moxi - platform + json; version = 1");
        //    client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        //    if (Session.Instance.IsSessionCookieSet)
        //    {
        //        client.DefaultRequestHeaders.Add("Cookie", string.Format("_wms_svc_public_session={0}", Session.Instance.Cookie));
        //    }
       
        //    client.GetAsync()

        //}

       
    }
}