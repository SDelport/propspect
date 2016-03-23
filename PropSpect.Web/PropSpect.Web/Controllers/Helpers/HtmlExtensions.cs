using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public enum ControlType { Textbox, Hidden, Dropdown, Signature, Number, File }

    public static class HtmlExtensions
    {

        public static MvcHtmlString ListAsync<TModel>(this Form<TModel> form, ListAsyncFormModel control)
        {
            return form.Html.Partial("Templates/Default/ListAsync", control);
        }

        public static MvcHtmlString Textbox<TModel, TValue>(this Form<TModel> form, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            FormControl control = GetControl(form, expression);

            return form.Html.Partial("Textbox", control);
        }

        public static MvcHtmlString Hidden<TModel, TValue>(this Form<TModel> form, Expression<Func<TModel, TValue>> expression) where TModel : class
        {
            FormControl control = GetControl(form, expression);

            return form.Html.Partial("Hidden", control);
        }

        public static MvcHtmlString SubmitButton<TModel>(this Form<TModel> form, string text)
        {
            return form.Html.Partial("Templates/Default/SubmitButton", text as object);
        }


        public static MvcHtmlString RenderTemplate<TModel>(this Form<TModel> form, FormControl control, string templateName)
        {
            return form.Html.Partial("Templates/Default/" + templateName, control);
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

        public static FormControl GetControl(PropertyInfo info, object currentObject)
        {
            FormControl control = new FormControl();

            control.Label = new MvcHtmlString(info.Name);
            control.Value = new MvcHtmlString(info.GetValue(currentObject, null).ToString());

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

        #region Lists
        public static ListAsyncFormModel GetListAsyncModel<T>(List<T> items) where T : new()
        {
            ListAsyncFormModel control = new ListAsyncFormModel();

            ListAsyncControl listControl = new ListAsyncControl();

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(List<SelectListItem>))
                    continue;

                ListOptions listOptions = property.GetCustomAttribute(typeof(ListOptions), false) as ListOptions;

                if (listOptions != null && listOptions.Hide)
                    continue;

                HeaderControl headerControl = new HeaderControl();
                headerControl.Label = new MvcHtmlString(property.Name);

                if (listOptions != null)
                {
                    if (!string.IsNullOrEmpty(listOptions.SourceName))
                    {
                        headerControl.Source = new MvcHtmlString(listOptions.SourceName);
                        headerControl.UseSource = true;
                    }
                }

                listControl.Headers.Add(headerControl);
            }

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(List<SelectListItem>))
                    continue;

                EditOptions editOptions = property.GetCustomAttribute(typeof(EditOptions), false) as EditOptions;

                EditControl editControl = new EditControl();
                editControl.Label = new MvcHtmlString(property.Name);

                if (editOptions != null)
                {
                    editControl.Type = editOptions.Type;
                    editControl.Source = new MvcHtmlString(editOptions.SourceName);
                }

                editControl.IsAsync = true;

                listControl.EditControls.Add(editControl);
            }

            control.Control = listControl;
            control.Control.Label = new MvcHtmlString(typeof(T).Name);
            control.EncodedItems = new MvcHtmlString(Json.Encode(items));

            T item = new T();
            control.EncodedTemplate = new MvcHtmlString(Json.Encode(item));

            return control;
        }
        #endregion

    }
}