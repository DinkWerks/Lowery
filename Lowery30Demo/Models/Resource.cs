﻿using Lowery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lowery30Demo.Models
{
	public class Resource
	{
		[PrimaryKey]
		public long ObjectID { get; set; }
		public long? PrimCo { get; set; }
		public string Label { get; set; }
		public string Description { get; set; }

		[Related("Resources_ResourceIdentifier")]
		public List<ResourceIdentifier> Identifiers { get; set; }
	}
}
