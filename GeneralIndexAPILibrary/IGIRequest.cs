using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public interface IGIRequest
    {
        IBodyParameters BodyParameters { get; }

        public HttpMethod Method { get; } 

        public string URL { get; }

        HttpContent Content { get; }
    }
}
