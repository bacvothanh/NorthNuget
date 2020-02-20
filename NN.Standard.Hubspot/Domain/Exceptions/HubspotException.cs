using System;
using System.Net.Http;

namespace NN.Standard.Hubspot.Domain.Exceptions
{
    public class HubspotException : Exception
    {
        public HubspotException(HttpResponseMessage httpResponseMessage) : base(GetErrorMessage(httpResponseMessage))
        {
        }

        private static string GetErrorMessage(HttpResponseMessage httpResponseMessage)
        {
            return $@"- [{httpResponseMessage.RequestMessage.Method.Method}] Uri: {httpResponseMessage.RequestMessage.RequestUri}
                      - Content {httpResponseMessage.RequestMessage.Content.ReadAsStringAsync().Result}
                      - Response {httpResponseMessage.Content.ReadAsStringAsync().Result}
                      - Status {httpResponseMessage.StatusCode}:{httpResponseMessage.ReasonPhrase}
                    ";
        }
    }
}
