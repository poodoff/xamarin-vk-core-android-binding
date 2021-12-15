using Com.VK.Api.Sdk;
using Com.VK.Api.Sdk.Internal;
using Java.Lang;
using Org.Json;
using VKontakte.Model;

namespace VKontakte.Requests
{
    public class UserInfoRequest : ApiCommand
    {
        const string METHOD = "users.get";

        protected override Java.Lang.Object OnExecute(VKApiManager manager)
        {
            var call = new VKMethodCall.Builder()
                .InvokeMethod(METHOD)
                .InvokeArgs("fields", "photo_400_orig")
                .InvokeVersion(manager.Config.Version)
                .Build();

            return manager.Execute(call, new UserInfoParser());
        }

        class UserInfoParser : Java.Lang.Object, IVKApiResponseParser
        {
            public Object Parse(string response)
            {
                var jsonArray = new JSONObject(response).GetJSONArray("response");
                if (jsonArray.Length() > 0)
                {
                    var userModel = new SimpleUserModel();
                    var firstElement = jsonArray.GetJSONObject(0);
                    userModel.FirstName = firstElement.OptString("first_name");
                    userModel.LastName = firstElement.OptString("last_name");
                    userModel.Photo400Orig = firstElement.OptString("photo_400_orig");

                    return userModel;
                }

                return null;
            }
        }
    }
}