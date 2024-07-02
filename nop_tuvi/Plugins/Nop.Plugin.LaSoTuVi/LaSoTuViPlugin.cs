using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.LaSoTuVi
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class LaSoTuViPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public LaSoTuViPlugin(ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            this._localizationService = localizationService;
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.HomePageTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/LaSoTuVi/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "LaSoTuVi";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //pictures
            //var sampleImagesPath = _fileProvider.MapPath("~/Plugins/LaSoTuVi/Content/nivoslider/sample-images/");

            ////settings
            //var settings = new LaSoTuViSettings
            //{
            //    Picture1Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(sampleImagesPath + "banner1.jpg"), MimeTypes.ImagePJpeg, "banner_1").Id,
            //    Text1 = "",
            //    Link1 = _webHelper.GetStoreLocation(false),
            //    Picture2Id = _pictureService.InsertPicture(_fileProvider.ReadAllBytes(sampleImagesPath + "banner2.jpg"), MimeTypes.ImagePJpeg, "banner_2").Id,
            //    Text2 = "",
            //    Link2 = _webHelper.GetStoreLocation(false)
            //    //Picture3Id = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner3.jpg"), MimeTypes.ImagePJpeg, "banner_3").Id,
            //    //Text3 = "",
            //    //Link3 = _webHelper.GetStoreLocation(false),
            //};
            //_settingService.SaveSetting(settings);


            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture1", "Picture 1");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture2", "Picture 2");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture3", "Picture 3");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture4", "Picture 4");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture5", "Picture 5");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture", "Picture");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Picture.Hint", "Upload picture.");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Text", "Comment");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Text.Hint", "Enter comment for picture. Leave empty if you don't want to display any text.");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Link", "URL");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.Link.Hint", "Enter URL. Leave empty if you don't want this picture to be clickable.");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.AltText", "Image alternate text");
            //_localizationService.AddOrUpdatePluginLocaleResource("Plugins.LaSoTuVi.AltText.Hint", "Enter alternate text that will be added to image.");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<LaSoTuViSettings>();

            //locales
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture1");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture2");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture3");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture4");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture5");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Picture.Hint");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Text");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Text.Hint");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Link");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.Link.Hint");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.AltText");
            //_localizationService.DeletePluginLocaleResource("Plugins.LaSoTuVi.AltText.Hint");

            base.Uninstall();
        }
    }
}