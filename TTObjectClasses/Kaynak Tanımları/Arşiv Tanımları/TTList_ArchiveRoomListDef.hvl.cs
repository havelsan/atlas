
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
    public partial class TTList_ArchiveRoomListDef : TTList
    {
        public TTList_ArchiveRoomListDef(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_ArchiveRoomListDef(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }
    }
}