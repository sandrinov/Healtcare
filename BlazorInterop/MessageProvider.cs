using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorInterop
{
    public static class MessageProvider
    {
        [JSInvokable]
        public static Task GetHelloMessage()
        {
            var message = "Hello from C#";
            return Task.FromResult(message);
        }
    }
}
