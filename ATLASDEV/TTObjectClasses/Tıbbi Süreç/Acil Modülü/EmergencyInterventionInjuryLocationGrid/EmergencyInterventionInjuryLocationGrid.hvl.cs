
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionInjuryLocationGrid")] 

    public  partial class EmergencyInterventionInjuryLocationGrid : TTObject
    {
        public class EmergencyInterventionInjuryLocationGridList : TTObjectCollection<EmergencyInterventionInjuryLocationGrid> { }
                    
        public class ChildEmergencyInterventionInjuryLocationGridCollection : TTObject.TTChildObjectCollection<EmergencyInterventionInjuryLocationGrid>
        {
            public ChildEmergencyInterventionInjuryLocationGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionInjuryLocationGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmerInterInjuryLocationGrid_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public InjuryLocation? InjuryLocation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INJURYLOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["INJURYLOCATION"].DataType;
                    return (InjuryLocation?)(int)dataType.ConvertValue(val);
                }
            }

            public InjuryDirectionOfLocation? InjuryDirectionOfLocation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INJURYDIRECTIONOFLOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["INJURYDIRECTIONOFLOCATION"].DataType;
                    return (InjuryDirectionOfLocation?)(int)dataType.ConvertValue(val);
                }
            }

            public string TypeOfInjury
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPEOFINJURY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["TYPEOFINJURY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? In
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["IN"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Out
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["OUT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetEmerInterInjuryLocationGrid_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmerInterInjuryLocationGrid_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmerInterInjuryLocationGrid_Class() : base() { }
        }

        public static BindingList<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class> GetEmerInterInjuryLocationGrid(string EIINJURYLOCATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].QueryDefs["GetEmerInterInjuryLocationGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EIINJURYLOCATION", EIINJURYLOCATION);

            return TTReportNqlObject.QueryObjects<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class> GetEmerInterInjuryLocationGrid(TTObjectContext objectContext, string EIINJURYLOCATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTIONINJURYLOCATIONGRID"].QueryDefs["GetEmerInterInjuryLocationGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EIINJURYLOCATION", EIINJURYLOCATION);

            return TTReportNqlObject.QueryObjects<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yaralanma Bölgesi
    /// </summary>
        public InjuryLocation? InjuryLocation
        {
            get { return (InjuryLocation?)(int?)this["INJURYLOCATION"]; }
            set { this["INJURYLOCATION"] = value; }
        }

    /// <summary>
    /// Yaralanma Bölgesi Yönü
    /// </summary>
        public InjuryDirectionOfLocation? InjuryDirectionOfLocation
        {
            get { return (InjuryDirectionOfLocation?)(int?)this["INJURYDIRECTIONOFLOCATION"]; }
            set { this["INJURYDIRECTIONOFLOCATION"] = value; }
        }

    /// <summary>
    /// Yaralanma Şekli(ASY,EYP,Diğer)
    /// </summary>
        public string TypeOfInjury
        {
            get { return (string)this["TYPEOFINJURY"]; }
            set { this["TYPEOFINJURY"] = value; }
        }

    /// <summary>
    /// Giriş
    /// </summary>
        public int? In
        {
            get { return (int?)this["IN"]; }
            set { this["IN"] = value; }
        }

    /// <summary>
    /// Çıkış
    /// </summary>
        public int? Out
        {
            get { return (int?)this["OUT"]; }
            set { this["OUT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public EmergencyInterventionInjuryLocation EIInjuryLocation
        {
            get { return (EmergencyInterventionInjuryLocation)((ITTObject)this).GetParent("EIINJURYLOCATION"); }
            set { this["EIINJURYLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONINJURYLOCATIONGRID", dataRow) { }
        protected EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONINJURYLOCATIONGRID", dataRow, isImported) { }
        public EmergencyInterventionInjuryLocationGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionInjuryLocationGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionInjuryLocationGrid() : base() { }

    }
}