using bzPubMedSearchViewModelByFody.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace bzPubMedSearchViewModelByFody.ViewModels
{
    public class PubMedSearchBuilderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<FieldNameItem> FieldNameItems { get; set; }
        public List<ConditionBuilderItem> ConditionBuilderItems { get; set; }
        public Action<string> StateHasChangedHandler { get; set; }
        public string QueryCondition { get; set; }
        public PubMedSearchBuilderViewModel()
        {
            FieldNameItems = new List<FieldNameItem>()
            {
                new FieldNameItem(){ FieldName="Author"},
                new FieldNameItem(){ FieldName="Author - Corporate"},
                new FieldNameItem(){ FieldName="Author - First"},
                new FieldNameItem(){ FieldName="Full"},
                new FieldNameItem(){ FieldName="Book"},
                new FieldNameItem(){ FieldName="Date - Create"},
            };
            ConditionBuilderItems = new List<ConditionBuilderItem>()
            {
                 
            };

        }
        public void InitData()
        {
            ConditionBuilderItems.Add(new ConditionBuilderItem()
            {
                NeedStateHasChangedHandler = StateHasChangedHandler
            });
            ConditionBuilderItems.Add(new ConditionBuilderItem()
            {
                NeedStateHasChangedHandler = StateHasChangedHandler
            });
        }

        public void AndOrLogicalSelectChanged(ChangeEventArgs e, ConditionBuilderItem item)
        {
            item.AndOrLogical = e.Value.ToString();
            Refresh();
        }
        public void FieldNameSelectChanged(ChangeEventArgs e, ConditionBuilderItem item)
        {
            item.FieldName = e.Value.ToString();
            Refresh();
        }

        public async Task RefreshInputAsync()
        {
            RefreshWhetherShowCommandButton();
            var itemLast = ConditionBuilderItems.Last();

            // 若沒有暫緩休息一下，則無法取得最新輸入的內容
            await Task.Delay(50);

            #region 若輸入的查詢條件內容是最後一筆，判斷是否要新增一筆空白查詢條件
            if (!string.IsNullOrWhiteSpace(itemLast.FieldValue))
            {
                ConditionBuilderItems.Add(new ConditionBuilderItem()
                {
                    NeedStateHasChangedHandler = StateHasChangedHandler
                });
            }
            #endregion
            RebuildConditionString();
        }

        public void RebuildConditionString()
        {
            QueryCondition = "";
            foreach (var item in ConditionBuilderItems)
            {
                if (item.FieldValue.Trim() == "")
                {
                    continue;
                }
                if (QueryCondition != "")
                {
                    QueryCondition = $"({QueryCondition}) {item.AndOrLogical} ";
                }

                if (item.FieldName.Trim() == "")
                {
                    QueryCondition = QueryCondition + item.FieldValue;
                }
                else
                {
                    QueryCondition = QueryCondition + $"{item.FieldValue}[{item.FieldName}]";
                }
            }
        }

        public void Refresh()
        {
            RefreshWhetherShowCommandButton();
            RebuildConditionString();
            //StateHasChanged();
            //StateHasChangedHandler?.Invoke();
       }

        public void RefreshWhetherShowCommandButton()
        {
            // 第一筆查詢條件的查詢邏輯控制項，不要顯示出來
            ConditionBuilderItems[0].ShowLogical = false;
            if (ConditionBuilderItems.Count == 1)
            {
                #region 若僅有一筆查詢條件，僅顯示可以新增查詢條件按鈕
                ConditionBuilderItems[0].ShowRemoveCondition = false;
                ConditionBuilderItems[0].ShowAddCondition = true;
                ConditionBuilderItems[0].ShowLogical = false;
                return;
                #endregion
            }
            else
            {
                bool first = false;
                foreach (var item in ConditionBuilderItems)
                {
                    if (first == false)
                    {
                        first = true;
                        #region 若有兩筆以上查詢條件，第一筆的查詢條件 新增與刪除按鈕要更新是否顯示出來
                        item.ShowRemoveCondition = true;
                        item.ShowAddCondition = false;
                        item.ShowLogical = false;
                        #endregion
                    }
                    else
                    {
                        item.ShowLogical = true;
                        item.ShowAddCondition = false;
                        item.ShowRemoveCondition = true;
                    }
                }
                ConditionBuilderItems.Last().ShowAddCondition = true;
            }
        }

        public void OnRemoveCondition(ConditionBuilderItem conditionBuilderItem)
        {
            var item = ConditionBuilderItems.FirstOrDefault(x => x.Id == conditionBuilderItem.Id);
            if (item != null)
            {
                ConditionBuilderItems.Remove(item);
            }
            Refresh();
        }

        public void OnAddCondition(ConditionBuilderItem conditionBuilderItem)
        {
            var item = ConditionBuilderItems.FirstOrDefault(x => x.Id == conditionBuilderItem.Id);
            if (item != null)
            {
                int idx = ConditionBuilderItems.IndexOf(item) + 1;
                ConditionBuilderItems.Insert(idx, new ConditionBuilderItem()
                {
                    NeedStateHasChangedHandler = StateHasChangedHandler
                });
            }
            Refresh();
        }
    }
}
