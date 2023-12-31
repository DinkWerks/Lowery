﻿using ArcGIS.Core.Data;
using Lowery.Mappings;
using System.Reflection;

namespace Lowery.Internal
{
	internal static class Common
    {
        internal static Dictionary<string, List<ExpandedPropertyInfo>> SortPropertyInfo(Type t)
        {
            Dictionary<string, List<ExpandedPropertyInfo>> results = new Dictionary<string, List<ExpandedPropertyInfo>>();
            var properties = t.GetProperties().Where(p => p.DeclaringType == t);

			List<ExpandedPropertyInfo> primaries = new();
            foreach ( var p in properties.Where(p => p.GetCustomAttribute<PrimaryKey>() != null))
            {
                string? fieldName = p.GetCustomAttribute<FieldName>()?.Name;
                primaries.Add(new ExpandedPropertyInfo(fieldName ?? p.Name, p) { IsPrimaryKey = true });
            }
            results.Add("PrimaryKey", primaries);

            List<ExpandedPropertyInfo> related = new();
			foreach (var p in properties.Where(p => p.GetCustomAttribute<Related>() != null))
			{
				string? fieldName = p.GetCustomAttribute<FieldName>()?.Name;
                string? relationName = p.GetCustomAttribute<Related>()?.RelationshipClass;
				related.Add(new ExpandedPropertyInfo(fieldName ?? p.Name, p) { IsRelational = true, RelationName = relationName });
			}
			results.Add("Related", related);

			List<ExpandedPropertyInfo> standard = new();
			foreach (var p in properties.Where(p => p.GetCustomAttribute<Related>() == null 
                && p.GetCustomAttribute<PrimaryKey>() == null 
                && p.GetCustomAttribute<Ignoreable>() == null))
			{
				string? fieldName = p.GetCustomAttribute<FieldName>()?.Name;
                standard.Add(new ExpandedPropertyInfo(fieldName ?? p.Name, p));
			}
			results.Add("StandardProps", standard);
            return results;
        }

        internal static void Dispose(IEnumerable<Row> rows)
        {
            foreach (Row row in rows)
                row.Dispose();
        }
    }
}
