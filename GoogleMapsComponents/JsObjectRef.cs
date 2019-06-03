﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleMapsComponents
{
    internal class JsObjectRef : IDisposable
    {
        protected readonly Guid _guid;
        protected readonly IJSRuntime _jsRuntime;

        public Guid Guid
        {
            get { return _guid; }
        }

        public IJSRuntime JSRuntime
        {
            get { return _jsRuntime; }
        }

        public JsObjectRef(
            IJSRuntime jsRuntime,
            Guid guid)
        {
            _jsRuntime = jsRuntime;
            _guid = guid;
        }

        public static Task<JsObjectRef> CreateAsync(
            IJSRuntime jsRuntime,
            string constructorFunctionName,
            params object[] args)
        {
            return CreateAsync(jsRuntime, Guid.NewGuid(), constructorFunctionName, args);
        }

        public async static Task<JsObjectRef> CreateAsync(
            IJSRuntime jsRuntime,
            Guid guid,
            string functionName,
            params object[] args)
        {
            var jsObjectRef = new JsObjectRef(jsRuntime, guid);

            await jsRuntime.MyInvokeAsync<object>(
                "googleMapsObjectManager.createObject",
                new object[] { guid.ToString(), functionName }
                    .Concat(args).ToArray()
            );

            return jsObjectRef;
        }

        //public JsObjectRef(
        //    IJSRuntime jsRuntime,
        //    string functionName,
        //    params object[] args)
        //    : this(jsRuntime, Guid.NewGuid(), functionName, args)
        //{
            
        //}

        //public JsObjectRef(
        //    IJSRuntime jsRuntime, 
        //    Guid guid, 
        //    string functionName,
        //    params object[] args)
        //{
        //    _jsRuntime = jsRuntime;
        //    _guid = guid;

        //    _jsRuntime.MyInvokeAsync<object>(
        //        "googleMapsObjectManager.createObject",
        //        new object[] { guid, functionName }
        //            .Concat(args).ToArray()
        //    );
        //}

        public virtual void Dispose()
        {
            DisposeAsync();
        }

        public Task DisposeAsync()
        {
            return _jsRuntime.InvokeAsync<object>(
                "googleMapsObjectManager.dispose",
                _guid.ToString()
            );
        }

        public Task<T> InvokeAsync<T>(string functionName, params object[] args)
        {
            return _jsRuntime.MyInvokeAsync<T>(
                "googleMapsObjectManager.invoke",
                new object[] { _guid.ToString(), functionName }
                    .Concat(args).ToArray()
            );
        }

        public async Task<JsObjectRef> InvokeWithReturnedObjectRefAsync(string functionName, params object[] args)
        {
            var guid = await _jsRuntime.MyInvokeAsync<string>(
                "googleMapsObjectManager.invokeWithReturnedObjectRef",
                new object[] { _guid.ToString(), functionName }
                    .Concat(args).ToArray()
            );

            return new JsObjectRef(_jsRuntime, new Guid(guid));
        }

        public override bool Equals(object obj)
        {
            var other = obj as JsObjectRef;

            if (other == null)
            {
                return false;
            }
            else
            {
                return other.Guid == this.Guid;
            }
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }
    }
}
