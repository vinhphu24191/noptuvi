using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.LaSoTuVi.Extern;
using Nop.Plugin.LaSoTuVi.Extern.Json;
using Nop.Plugin.LaSoTuVi.Models;
using Nop.Plugin.LaSoTuVi.Models.LaSoTuVi;
using Nop.Plugin.LaSoTuVi.TuViSerives.Data;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.LaSoTuVi.Controllers
{
    [Area(AreaNames.Admin)]
    public class LaSoTuViController : BasePluginController
    {
        private readonly IStoreContext _storeContext;
        private readonly IPermissionService _permissionService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public LaSoTuViController(IStoreContext storeContext,
            IPermissionService permissionService,
            IPictureService pictureService,
            ISettingService settingService,
            ICacheManager cacheManager,
            ILocalizationService localizationService)
        {
            this._storeContext = storeContext;
            this._permissionService = permissionService;
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        //public IActionResult TrangChu()
        //{
        //    return View("~/Plugins/LaSoTuVi/Views/TrangChu.cshtml");
        //}
        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var nivoSliderSettings = _settingService.LoadSetting<LaSoTuViSettings>(storeScope);
            var model = new ConfigurationModel
            {

            };

            return View("~/Plugins/LaSoTuVi/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();


            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }


    }
}