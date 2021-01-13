﻿using Microsoft.AspNetCore.Components;
using System;

namespace BitLib
{
    /// <summary>
    /// The Material Design color system can be used to create a color theme that reflects your brand or style.
    /// </summary>
    public class BaseBitThemeProvider : ComponentBase, IDisposable
    {
        private BitTheme _theme;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public BitTheme Theme
        {
            get => _theme;
            set
            {
                if (_theme == value)
                {
                    return;
                }

                if (_theme != null)
                {
                    _theme.Changed -= _theme_Changed;
                }

                _theme = value;

                if (_theme != null)
                {
                    _theme.Changed += _theme_Changed;
                }
            }
        }

        private void _theme_Changed(object sender, System.EventArgs e)
        {
            this.StateHasChanged();
        }

        public void Dispose()
        {
            if (_theme != null)
            {
                _theme.Changed -= _theme_Changed;
            }
        }
    }
}
