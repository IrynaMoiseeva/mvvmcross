using Android.Content;
using Android.Widget;
using Com.Google.Android.Youtube.Player;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Core;
using MvvmCross_Application1.Core;
using MvvmCross_Application1.Droid.Views;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MvvmCross_Application1.Core.Data;
using Autofac.Extras.MvvmCross;
using System;
using MvvmCross_Application1.Droid.Properties;
using MvvmCross_Application1.Core.Services;

namespace MvvmCross_Application1.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly


    };

        // add more abbreviations here

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
            // registry.RegisterFactory(new MvxCustomBindingFactory<YouTubeThumbnailView>("Tag", (tag) => new MyCustomBinding(tag)));
            registry.RegisterPropertyInfoBindingFactory(
        typeof(MyCustomBinding),
        typeof(YouTubeThumbnailView), "Tag");
        }


        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter =
                new MvxAndroidViewPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }
        protected override IMvxIoCProvider CreateIocProvider()
        {
            Dictionary<Type, Type> mappedtypes = new Dictionary<Type, Type>();
            mappedtypes.Add(typeof(PlatformService_Android), typeof(IPlatformService));
            Bootstarpper bootstarpper = new Bootstarpper();
            var container = bootstarpper.Build(mappedtypes);
            return new AutofacMvxIocProvider(container);
        }
    }
}













