using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace bzPubMedSearchViewModelByFody.Models
{
    public class ConditionBuilderItem: INotifyPropertyChanged
    {
        public Action<string> NeedStateHasChangedHandler { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool ShowLogical { get; set; } = true;
        public string AndOrLogical { get; set; } = "And";
        public string FieldName { get; set; } = " ";
        public string FieldValue { get; set; } = "";
        public bool ShowAddCondition { get; set; } = true;
        public bool ShowRemoveCondition { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnAndOrLogicalChanged()
        {
            NeedStateHasChangedHandler?.Invoke(nameof(AndOrLogical));
        }
        public void OnFieldValueChanged()
        {
            NeedStateHasChangedHandler?.Invoke(nameof(FieldValue));
        }
        public void OnFieldNameChanged()
        {
            NeedStateHasChangedHandler?.Invoke(nameof(FieldName));
        }
    }
}
