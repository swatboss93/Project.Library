using Abp.Web.Mvc.Views;

namespace Project.Library.Web.Views
{
    public abstract class LibraryWebViewPageBase : LibraryWebViewPageBase<dynamic>
    {

    }

    public abstract class LibraryWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LibraryWebViewPageBase()
        {
            LocalizationSourceName = LibraryConsts.LocalizationSourceName;
        }
    }
}