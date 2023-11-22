﻿using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using Lowery;
using LoweryDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoweryDemo.Controls
{
    internal class GetRecords : Button
    {
        protected override async void OnClick()
        {
            var reg = Module1.Current.LoweryMap.Registry("Main");
            var result = await reg.Retrieve<LoweryStandaloneTable>("Resources").Get<Resource>("objectid = 1");
        }

    }

    internal class InsertRecords : Button
    {
        protected override async void OnClick()
        {
            /*
            var t = Module1.Current.LoweryMap.Table("Resources");
            long oid = await t.Insert(
                new Resource()
                {
                    Label = "Iota",
                    Description = "I should learn the Greek alphabet."
                });
            */
        }
    }
}
