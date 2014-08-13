﻿using Easy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easy.MetaData;
using System.Collections.ObjectModel;

namespace Easy.CMS.Layout
{
    [DataConfigure(typeof(LayoutHtmlMetaData))]
    public class LayoutHtml : EditorEntity
    {
        public int LayoutHtmlId { get; set; }
        public string LayoutId { get; set; }
        public string Html { get; set; }
    }
    public class LayoutHtmlCollection : Collection<LayoutHtml>
    {

    }
    class LayoutHtmlMetaData : DataViewMetaData<LayoutHtml>
    {
        protected override void DataConfigure()
        {
            DataTable("CMS_LayoutHtml");
            DataConfig(m => m.LayoutHtmlId).AsIncreasePrimaryKey();
        }

        protected override void ViewConfigure()
        {

        }
    }

}
