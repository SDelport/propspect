using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString EndForm(this Form<object> form)
        {
            return new MvcHtmlString("</form>");
        }

        public static MvcHtmlString Textbox<TModel, TValue>(this Form<TModel> form, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            FormControl control = GetControl(form, expression);

            return form.Html.Partial("Templates/Default/Textbox", control);
        }

        public static MvcHtmlString Hidden<TModel, TValue>(this Form<TModel> form, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            FormControl control = GetControl(form, expression);

            return form.Html.Partial("Templates/Default/Hidden", control);
        }

        public static MvcHtmlString SubmitButton<TModel>(this Form<TModel> form, string text)
        {
            return form.Html.Partial("Templates/Default/SubmitButton", text as object);
        }




        public static FormControl GetControl<TModel, TValue>(this Form<TModel> form, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            FormControl control = new FormControl();
            ModelMetadata modelData = GetModelData(form.Html, expression);
            string value = GetValueFromModelData(modelData, expression);
            control.Label = new MvcHtmlString(modelData.DisplayName ?? modelData.PropertyName);
            control.Value = new MvcHtmlString(value);

            return control;
        }

        public static ModelMetadata GetModelData<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
          where TModel : class
        {
            return ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, helper.ViewData);
        }

        public static string GetValueFromModelData<TModel, TValue>(ModelMetadata modelData, Expression<Func<TModel, TValue>> expression)
            where TModel : class
        {
            if (modelData.Container == null)
                return "";

            var val = expression.Compile()(modelData.Container as TModel);
            if (val == null)
                return "";

            return val.ToString();
        }

    }
}