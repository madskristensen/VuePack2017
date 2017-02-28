using System;
using System.Runtime.InteropServices;
using System.Threading;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace VuePack
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideAutoLoad(UIContextGuids80.SolutionHasSingleProject, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(UIContextGuids80.SolutionHasMultipleProjects, PackageAutoLoadFlags.BackgroundLoad)]
    [Guid("b2295a37-9de5-4be8-8a5e-7bbb7ecdc3ca")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class VuePackage : AsyncPackage
    {
        private SolutionEvents _events;

        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            var dte = await GetServiceAsync(typeof(DTE)) as DTE2;

            _events = dte.Events.SolutionEvents;
            _events.AfterClosing += delegate { DirectivesCache.Clear(); };
        }
    }
}
