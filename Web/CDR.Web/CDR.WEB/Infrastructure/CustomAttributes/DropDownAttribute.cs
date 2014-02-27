using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDR.Web.Infrastructure.CustomAttributes
{
    /// <summary>
    /// Display as dropdown Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CustomDropDownAttribute : Attribute, IMetadataAware
    {
        /// <summary>
        /// Gets or sets the name of the source property.
        /// </summary>
        /// <value>
        /// The name of the source property.
        /// </value>
        public string LookupMethodName { get; set; }

        public bool AddLookupData { get; set; }

        public string LookupType { get; set; }


        /// <summary>
        /// When implemented in a class, provides metadata to the model metadata creation process.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("LookupMethodName", this.LookupMethodName);
            metadata.AdditionalValues.Add("AddLookupData", this.AddLookupData);
            metadata.AdditionalValues.Add("LookupType",this.LookupType);
            metadata.TemplateHint = "DropDownList";
        }

        
    }

}
