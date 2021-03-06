/* http://www.zkea.net/ Copyright 2016 ZKEASOFT http://www.zkea.net/licenses */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Easy.Data;
using Easy.Data.ValueProvider;
using Easy.MetaData;
using Easy.Models;
using MvcApplication.Service;

namespace MvcApplication.Models
{
    [DataConfigure(typeof(ExampleMetaData))]
    public class Example : EditorEntity
    {
        public int Id { get; set; }
        [DisplayName("文本")]
        public string Text { get; set; }
        public string Value { get; set; }
        public ICollection<ExampleItem> Items { get; set; }
    }

    class ExampleMetaData : DataViewMetaData<Example>
    {

        protected override void DataConfigure()
        {
            DataTable("Example");
            DataConfig(m => m.Id).AsIncreasePrimaryKey();
            DataConfig(m => m.Value).Mapper("ValueText").SetValueProvider(new GuidProvider());
            DataConfig(m => m.Title).Ignore();
            DataConfig(m => m.Items)
                .SetReference<ExampleItem, IExampleItemService>((example, exampleItem) => TargetType.Name == exampleItem.OwnerId);

        }

        protected override void ViewConfigure()
        {
            ViewConfig(m => m.Id).AsHidden();
            ViewConfig(m => m.Text).AsTextBox().Required();
            ViewConfig(m => m.Value).AsTextArea().MaxLength(200);
            ViewConfig(m => m.Items).AsListEditor();
        }

    }
}