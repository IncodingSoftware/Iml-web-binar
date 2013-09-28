namespace IML
{
    #region << Using >>

    using System;
    using System.Web.Mvc;
    using Incoding.MvcContrib;

    #endregion

    public static class HtmlExtensions
    {
        #region Factory constructors

        public static MvcHtmlString Load(this HtmlHelper htmlHelper, Action<LoadSetting> action)
        {
            var setting = new LoadSetting();
            action(setting);

            return htmlHelper.When(JqueryBind.None)
                             .Do()
                             .AjaxGet(setting.Url)
                             .OnSuccess(dsl =>
                                            {
                                                if (setting.IsAppend)
                                                    dsl.Self().Core().Insert.WithTemplate(setting.Template).Append();
                                                else
                                                    dsl.Self().Core().Insert.WithTemplate(setting.Template).Html();
                                            })
                             .AsHtmlAttributes(new { id = setting.Id })
                             .ToDiv();
        }

        #endregion

        #region Nested classes

        public class LoadSetting
        {
            #region Properties

            public string Id { get; set; }

            public string Url { get; set; }

            public Selector Template { get; set; }

            public bool IsAppend { get; set; }

            #endregion
        }

        #endregion
    }
}