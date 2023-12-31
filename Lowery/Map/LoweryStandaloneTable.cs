﻿using ArcGIS.Core.Data;
using ArcGIS.Desktop.Mapping;
using Lowery.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowery
{
    public class LoweryStandaloneTable : LoweryBase, ILoweryItem
	{
		public string Name { get; }
		public string Uri { get; set; }
		public DataSource DataSource { get; set; }
		public string? Parent { get; set; }
		public ItemRegistry? Registry { get; set; }
		public IEnumerable<LoweryFieldDefinition>? MandatoryFields { get; set; }

		public LoweryStandaloneTable(LoweryTableDefintion defintion, StandaloneTable instance)
		{
			Name = defintion.Name;
			Uri = instance.URI;
			Parent = defintion.Parent;
			MandatoryFields = defintion.MandatoryFields;
			MapMember = instance;
			DisplayTable = instance;
		}

		public async Task<bool> ValidateDefinition(ILoweryDefinition definition)
		{
			return await Task.FromResult(true);
		}

	}
}
