using Core.Models.DataSourceOptionsParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTUtils;

namespace Core.Models
{
    public class DataSourceLoadOptions
    {
        /// <summary>
        /// A flag indicating whether the total number of data objects is required.
        /// </summary>
        public bool RequireTotalCount { get; set; }

        /// <summary>
        /// A flag indicating whether the number of top-level groups is required.
        /// </summary>
        public bool RequireGroupCount { get; set; }

        /// <summary>
        /// A flag indicating whether the current query is made to get the total number of data objects.
        /// </summary>
        public bool IsCountQuery { get; set; }

        /// <summary>
        /// The number of data objects to be skipped from the start of the resulting set.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// The number of data objects to be loaded.
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// A sort expression.
        /// </summary>
        public SortingInfo[] Sort { get; set; }

        /// <summary>
        /// A group expression.
        /// </summary>
        public GroupInfo[] Group { get; set; }

        /// <summary>
        /// A filter expression.
        /// </summary>
        public IList Filter { get; set; }

        /// <summary>
        /// A total summary expression.
        /// </summary>
        public object[] TotalSummary { get; set; }

        /// <summary>
        /// A group summary expression.
        /// </summary>
        public object[] GroupSummary { get; set; }

        /// <summary>
        /// A select expression.
        /// </summary>
        public string[] Select { get; set; }

        /// <summary>
        /// An array of data fields that limits the <see cref="Select" /> expression.
        /// The applied select expression is the intersection of <see cref="PreSelect" /> and <see cref="Select" />.
        /// </summary>
        public string[] PreSelect { get; set; }

        /// <summary>
        /// A flag that indicates whether the LINQ provider should execute the select expression.
        /// If set to false, the select operation is performed in memory.
        /// </summary>
        public bool? RemoteSelect { get; set; }

        /// <summary>
        /// A flag that indicates whether the LINQ provider should execute grouping.
        /// If set to false, the entire dataset is loaded and grouped in memory.
        /// </summary>
        public bool? RemoteGrouping { get; set; }

        /// <summary>
        /// An array of primary keys.
        /// </summary>
        public string[] PrimaryKey { get; set; }

        /// <summary>
        /// The data field to be used for sorting by default.
        /// </summary>
        public string DefaultSort { get; set; }

        /// <summary>
        /// A flag that indicates whether filter expressions should include a ToLower() call that makes string comparison case-insensitive.
        /// Defaults to true for LINQ to Objects, false for any other provider.
        /// </summary>
        public bool? StringToLower { get; set; }
        public dynamic Params { get; set; }

        public bool? IsLoadingAll { get; set; }

    }



}
