using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Exceptions;

namespace GrooveSharp.Protocol.Commands
{
    internal class AsyncCommand<TRequestData, TResponseData> : AsyncCommandBase<TRequestData, TResponseData> where TRequestData : new()
    {
        private readonly RequestToken<TRequestData> request;

        public override TRequestData Parameters { get { return this.request.Parameters; } }

        public AsyncCommand(ISession session, string method) : base(session)
        {
            this.request = this.RequestDataIsAStreamCommand() ? this.CreateStreamRequestToken(method) : this.CreateRequestToken(method);
        }

        protected override WebRequest CreateWebRequest()
        {
            var webRequest = WebRequest.Create(this.CreateUrl());
            webRequest.Method = "POST";
 
            WriteRequest(webRequest);

            return webRequest;
        }

        protected override TResponseData OnEndExecution(WebResponse webResponse)
        {
            var response = this.CreateResponseToken(webResponse);
            return this.CheckIsFaulted(response);
        }

        private void WriteRequest(WebRequest webRequest)
        {
            var asyncState = webRequest.BeginGetRequestStream(_ => { }, webRequest);
            var stream = webRequest.EndGetRequestStream(asyncState);
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(this.Session.Parser.GetStringFromObject(this.request));
            }
        }

        private RequestToken<TRequestData> CreateRequestToken(string method)
        {
            return new RequestToken<TRequestData>
                       {
                           Method = method,
                           Header = new RequestTokenHeader
                                        {
                                            Client = this.Session.Client,
                                            ClientRevision = this.Session.ClientRevision,
                                            Country = this.Session.Country,
                                            Privacy = this.Session.Privacy,
                                            SessionId = this.Session.SessionId,
                                            Token = this.Session.Tokenizer(method),
                                            Uuid = this.Session.Uuid
                                        }
                       };

        }

        private RequestToken<TRequestData> CreateStreamRequestToken(string method)
        {
            return new RequestToken<TRequestData>
                        {
                            Method = method,
                            Header = new RequestTokenHeader
                                        {
                                            Client = this.Session.StreamClient,
                                            ClientRevision = this.Session.StreamClientRevision,
                                            Country = this.Session.Country,
                                            Privacy = this.Session.Privacy,
                                            SessionId = this.Session.SessionId,
                                            Token = this.Session.Tokenizer(method, true),
                                            Uuid = this.Session.Uuid
                                        }
                        };

        }

        private string CreateUrl()
        {
            var protocol = this.UseSslConnection() ? "https" : "http";
            return string.Format("{0}://{1}/more.php?{2}", protocol, this.Session.ServerUrl, this.request.Method);
        }

        private ResponseToken<TResponseData> CreateResponseToken(WebResponse response)
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var responseContent = reader.ReadToEnd();
                return this.Session.Parser.GetObjectFromString<ResponseToken<TResponseData>>(responseContent);
            }
        }

        private TResponseData CheckIsFaulted(ResponseToken<TResponseData> response)
        {
            if (response.IsFaulted)
            {
                throw new GrooveException(response.Fault);
            }

            if (response.Header.ExpiredClient)
            {
                Debug.WriteLine("[!] The client has expired");
            }

            return response.Result;
        }

        private bool UseSslConnection()
        {
            return ObjectTypeHasAttribute(typeof(TRequestData), typeof(UseSslAttribute));
        }

        private bool RequestDataIsAStreamCommand()
        {
            return ObjectTypeHasAttribute(typeof (TRequestData), typeof (StreamCommandAttribute));
        }

        private static bool ObjectTypeHasAttribute(Type theType, Type attributeType)
        {
            return theType.HasAttribute(attributeType);
        }
    }
}
// attributes = theType.GetCustomAttributes(false);
//            return attributes.Any(attribute => attribute.GetType() == attributeType);
//#else
//            return theType.GetTypeInfo().GetCustomAttribute(attributeType) != null;
//#endif
            
//        }
//    }
//}
