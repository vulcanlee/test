using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzPubMedSearchViewModel.Models
{
    public class ConditionBuilderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool ShowLogical { get; set; } = true;
        public string AndOrLogical { get; set; } = "And";
        public string FieldName { get; set; } = " ";
        public string FieldValue { get; set; } = "";
        public bool ShowAddCondition { get; set; } = true;
        public bool ShowRemoveCondition { get; set; } = true;
    }
}
