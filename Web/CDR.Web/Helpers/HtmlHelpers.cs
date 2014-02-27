using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CDR.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString GenericDropDownList(this HtmlHelper html, string expression, object attributes)
        {
            var model = html.ViewData.Model;
            var propertyMetadata = html.ViewData.ModelMetadata.Properties.Single(x => x.PropertyName == expression);

            ////Retrives the SourcePropertyName from DropDown Attribute
            var dataSourcePropertyName = propertyMetadata.AdditionalValues["LookupMethodName"].ToString();

            ////Fetch the current instance/value of the SourceProperty Name
            System.Reflection.PropertyInfo propertyInfo = model.GetType().GetProperty(dataSourcePropertyName);
            var selectList = (SelectList)propertyInfo.GetValue(model, null);

            ////Generate the DropDownList
            return html.DropDownList(propertyMetadata.PropertyName, selectList, propertyMetadata.DisplayName, attributes);
        }

    }
}