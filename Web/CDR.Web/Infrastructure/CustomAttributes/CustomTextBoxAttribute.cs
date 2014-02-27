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
    public sealed class CustomTextBoxAttribute : Attribute, IMetadataAware
    {
        /// <summary>
        /// Gets or sets the name of the source property.
        /// </summary>
        /// <value>
        /// The name of the source property.
        /// </value>
        public bool IsDateType { get; set; }

        public bool IsMultiline { get; set; }

        public DateTime? DefaultDate { get; set; }


        /// <summary>
        /// When implemented in a class, provides metadata to the model metadata creation process.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("IsDateType", this.IsDateType);
            metadata.AdditionalValues.Add("IsMultiline", this.IsMultiline);
        }
    }

}
