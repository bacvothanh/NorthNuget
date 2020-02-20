using System;

namespace NN.Standard.Facebook.Domain.Models
{
    public class FacebookConfig
    {
        public Uri Uri { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string AccountKitId { get; set; }
        public string AccountKitSecret { get; set; }
    }
}
