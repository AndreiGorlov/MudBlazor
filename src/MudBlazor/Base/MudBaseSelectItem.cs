﻿using System.Windows.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MudBlazor
{
    public abstract class MudBaseSelectItem : MudComponentBase
    {
        /// <summary>
        /// If true, the input element will be disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// If true, disables ripple effect.
        /// </summary>
        [Parameter] public bool DisableRipple { get; set; }

        /// <summary>
        /// Link to a URL when clicked.
        /// </summary>
        [Parameter] public string Href { get; set; }

        /// <summary>
        /// Child content of component.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Command parameter.
        /// </summary>
        [Parameter] public object CommandParameter { get; set; }

        /// <summary>
        /// Command executed when the user clicks on an element.
        /// </summary>
        [Parameter] public ICommand Command { get; set; }
        [Inject] public Microsoft.AspNetCore.Components.NavigationManager UriHelper { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        protected void OnClickHandler(MouseEventArgs ev)
        {
            if (Href != null)
            {
                UriHelper.NavigateTo(Href);
            }
            else
            {
                OnClick.InvokeAsync(ev);
                if (Command?.CanExecute(CommandParameter) ?? false)
                {
                    Command.Execute(CommandParameter);
                }
            }
        }
    }
}
