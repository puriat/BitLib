using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace BitLib.Components.Button
{
    public partial class BitButton : BaseBitDomComponent
    {
        private ClassMapper SecondaryTextClassMapper { get; } = new ClassMapper();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //we can add sass to prevent from initiating another class mapper.
            ClassMapper
                .Add("bit-button")
                .Add("bit-button-theme-" + (ButtonTheme == ButtonTheme.Standard ? "standard" : "primary"))
                .If("bit-button-secondary-text-addition", () => !string.IsNullOrEmpty(SecondaryText))
                .If("bit-button-disabled", () => this.Disabled);

            if (!String.IsNullOrEmpty(SecondaryText))
                SecondaryTextClassMapper
                    .Add("bit-button-secondary-text")
                    .If("bit-button-secondary-text-primary", () => ButtonTheme == ButtonTheme.Primary)
                    .If("bit-button-secondary-text-disabled", () => Disabled);
        }

        [Parameter] public string Text { get; set; }
        [Parameter] public string SecondaryText { get; set; }
        [Parameter] public bool Disabled { get; set; }
        //it can be a bool variable(ex : primary)
        [Parameter] public ButtonTheme ButtonTheme { get; set; }


        /// <summary>
        /// Event occurs when the user clicks on an element.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        //The existance of this function is for future use, in case if we want to add extra action on click like logging
        private async void OnClickHandler(MouseEventArgs ev)
        {
            if (Disabled)
                return;
            await OnClick.InvokeAsync(ev);
        }
    }

    public enum ButtonTheme
    {
        Standard,
        Primary
    }
}
