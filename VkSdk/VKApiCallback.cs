using System;
using Com.VK.Api.Sdk;

namespace VKontakte
{
    public class VKApiCallback<T> : Java.Lang.Object, IVKApiCallback where T : Java.Lang.Object
    {
        private readonly Action<T> _successAction;
        private readonly Action<Exception> _failAction;

        public VKApiCallback(Action<T> successAction, Action<Exception> failAction)
        {
            _successAction = successAction;
            _failAction = failAction;
        }

        public void Fail(Java.Lang.Exception error)
        {
            _failAction?.Invoke(new Exception("Callback fail", error));
        }

        public void Success(Java.Lang.Object result)
        {
            if (result == null)
            {
                _failAction?.Invoke(new Exception("Null result"));
            }
            else if (!(result is T))
            {
                _failAction?.Invoke(new InvalidCastException("Mismatch result type"));
            }
            else
            {
                _successAction?.Invoke(result as T);
            }
        }
    }
}