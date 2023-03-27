
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class PatientFolderDefinition : TTDefinitionSet
    {
#region Methods
        private static SortedList<int, PatientFolderDefinition> _allEpisodeColumns;
        public static SortedList<int, PatientFolderDefinition> AllEpisodeColumns
        {
            get { return _allEpisodeColumns; }
        }

        private static SortedList<int, PatientFolderDefinition> _allActionColumns;
        public static SortedList<int, PatientFolderDefinition> AllActionColumns
        {
            get { return _allActionColumns; }
        }
        
        static PatientFolderDefinition()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allEpisodeColumns = new SortedList<int, PatientFolderDefinition>();
            _allActionColumns = new SortedList<int, PatientFolderDefinition>();
            foreach (PatientFolderDefinition pfd in context.QueryObjects(typeof(PatientFolderDefinition).Name))
            {
                if (pfd.HeaderType == HeaderTypeEnum.Episode)
                    _allEpisodeColumns.Add(pfd.OrderNo.Value, pfd);
                else if (pfd.HeaderType == HeaderTypeEnum.Action)
                    _allActionColumns.Add(pfd.OrderNo.Value, pfd);
            }
            
        }
        
#endregion Methods

    }
}