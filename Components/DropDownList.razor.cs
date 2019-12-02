using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSL.BlazorWebForms.Components
{
    public class DropDownListComponent : ControlComponent
    {
        public DropDownListComponent()
        {
            DataSource = new List<Models.IDropDownListItem>();
        }

        internal void AddItem(
            DropDownListItemComponent item)
        {
            DataSource.Add(new Models.Item
            {
                Text = item.Text,
                Value = item.Value ?? item.Text
            });

            if (item.Selected)
            {
                SelectedValue = item.Value ?? item.Text;
                SelectedValueChanged.InvokeAsync(SelectedValue).GetAwaiter();
            }
        }
        
        [Parameter]
        public string SelectedValue { get; set; }

        [Parameter]
        public EventCallback<string> SelectedValueChanged { get; set; }

        [Parameter]
        public List<Models.IDropDownListItem> DataSource { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        protected async Task OnChangeAsync(
            ChangeEventArgs e)
        {
            SelectedValue = e.Value.ToString();

            await SelectedValueChanged.InvokeAsync(SelectedValue);
        }
    }
}
