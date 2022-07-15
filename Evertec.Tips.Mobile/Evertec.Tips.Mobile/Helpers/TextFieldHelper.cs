using System;
using System.Reflection;
using System.Resources;
using Evertec.Tips.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Evertec.Tips.Mobile.Helpers
{
    [ContentProperty("Text")]
    public class TextFieldHelper : IMarkupExtension
    {
        private const string ResourceId = "Evertec.Tips.Mobile.Resources.AppResources";

        private static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TextFieldHelper).GetTypeInfo().Assembly));

        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return default(string);

            var translation = resmgr.Value.GetString(Text, AppResources.Culture);

            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }

        public static string Get(string key)
        {
            var result = AppResources.ResourceManager.GetString(key);
            return result;
        }
    }
}
