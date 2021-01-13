using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BitLib
{
    public abstract class BaseBitDomComponent : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = IdGeneratorHelper.Generate("bitLib_id_");

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }


        [CascadingParameter]
        public BitTheme Theme { get; set; }

        protected ClassMapper ClassMapper { get; } = new ClassMapper();


        protected BaseBitDomComponent()
        {
            ClassMapper
                .Get(() => this.Class)
                .Get(() => this.Theme?.GetClass());
            
            StyleMapper.Get(() => Style);
        }

        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
        [Parameter]
        public string Class { get; set; }


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string Style { get; set; }


        protected StyleMapper StyleMapper = new StyleMapper();
    }
}