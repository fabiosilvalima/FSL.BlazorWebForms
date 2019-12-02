using FSL.BlazorWebForms.Components;

namespace FSL.BlazorWebForms.Models
{
    public class Item : IDropDownListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
