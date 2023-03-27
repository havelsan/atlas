
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendToENabiz")] 

    public  partial class SendToENabiz : TTObject
    {
        public class SendToENabizList : TTObjectCollection<SendToENabiz> { }
                    
        public class ChildSendToENabizCollection : TTObject.TTChildObjectCollection<SendToENabiz>
        {
            public ChildSendToENabizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendToENabizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCountOfSuccesPackage_Class : TTReportNqlObject 
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

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RecordDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["RECORDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCountOfSuccesPackage_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfSuccesPackage_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfSuccesPackage_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountOfToBeSentPackage_Class : TTReportNqlObject 
        {
            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCountOfToBeSentPackage_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfToBeSentPackage_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfToBeSentPackage_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSentToENabizMaterial_Class : TTReportNqlObject 
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

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RecordDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["RECORDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSentToENabizMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSentToENabizMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSentToENabizMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class HasSentToENabiz_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public HasSentToENabiz_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HasSentToENabiz_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HasSentToENabiz_Class() : base() { }
        }

        [Serializable] 

        public partial class SendToENabizLog_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Senddate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SENDDATE"]);
                }
            }

            public Object Responsemessage
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSEMESSAGE"]);
                }
            }

            public Object Responsecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                }
            }

            public string SYSTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SendToENabizLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SendToENabizLog_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNabizPackagesBySubepisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Senddate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SENDDATE"]);
                }
            }

            public Object Responsemessage
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSEMESSAGE"]);
                }
            }

            public Object Responsecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                }
            }

            public string SYSTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNabizPackagesBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNabizPackagesBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNabizPackagesBySubepisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEnabizPackagesByProtocolNo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Senddate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SENDDATE"]);
                }
            }

            public Object Responsemessage
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSEMESSAGE"]);
                }
            }

            public Object Responsecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                }
            }

            public string SYSTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEnabizPackagesByProtocolNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEnabizPackagesByProtocolNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEnabizPackagesByProtocolNo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEnabizPackagesByPatientID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Senddate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SENDDATE"]);
                }
            }

            public Object Responsemessage
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSEMESSAGE"]);
                }
            }

            public Object Responsecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                }
            }

            public string SYSTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["SYSTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEnabizPackagesByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEnabizPackagesByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEnabizPackagesByPatientID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPackagesByErrorCode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPackagesByErrorCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPackagesByErrorCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPackagesByErrorCode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPackageDetailsBySubepisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? RecordDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["RECORDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPackageDetailsBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPackageDetailsBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPackageDetailsBySubepisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountOfSuccesPackageBySubepisode_Class : TTReportNqlObject 
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

            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RecordDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["RECORDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCountOfSuccesPackageBySubepisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfSuccesPackageBySubepisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfSuccesPackageBySubepisode_Class() : base() { }
        }

        public static BindingList<SendToENabiz> GetToBeSentWithPackageCode(TTObjectContext objectContext, string PACKAGECODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetToBeSentWithPackageCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz.GetCountOfSuccesPackage_Class> GetCountOfSuccesPackage(Guid INTERNALOBJECTID, string PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfSuccesPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfSuccesPackage_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetCountOfSuccesPackage_Class> GetCountOfSuccesPackage(TTObjectContext objectContext, Guid INTERNALOBJECTID, string PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfSuccesPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfSuccesPackage_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz> GetByObjectID(TTObjectContext objectContext, Guid INTERNALOBJECTID, string PACKAGECODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz> GetByObjectIDWhichHasSYSTakipNo(TTObjectContext objectContext, Guid INTERNALOBJECTID, string PACKAGECODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetByObjectIDWhichHasSYSTakipNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz> GetToBeSent(TTObjectContext objectContext, string PACKAGECODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetToBeSent"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz> GetByObjectIDNameCodeAndStatus(TTObjectContext objectContext, Guid OBJECTID, string OBJECTDEFNAME, string PACKAGECODE, SendToENabizEnum STATUS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetByObjectIDNameCodeAndStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("STATUS", (int)STATUS);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz.GetCountOfToBeSentPackage_Class> GetCountOfToBeSentPackage(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfToBeSentPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfToBeSentPackage_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetCountOfToBeSentPackage_Class> GetCountOfToBeSentPackage(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfToBeSentPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfToBeSentPackage_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz> GetbySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetbySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

        public static BindingList<SendToENabiz.GetSentToENabizMaterial_Class> GetSentToENabizMaterial(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetSentToENabizMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetSentToENabizMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetSentToENabizMaterial_Class> GetSentToENabizMaterial(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetSentToENabizMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetSentToENabizMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Nabızda satırı olanlar
    /// </summary>
        public static BindingList<SendToENabiz.HasSentToENabiz_Class> HasSentToENabiz(IList<Guid> INTERNALOBJECTID, int PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["HasSentToENabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.HasSentToENabiz_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Nabızda satırı olanlar
    /// </summary>
        public static BindingList<SendToENabiz.HasSentToENabiz_Class> HasSentToENabiz(TTObjectContext objectContext, IList<Guid> INTERNALOBJECTID, int PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["HasSentToENabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTERNALOBJECTID", INTERNALOBJECTID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.HasSentToENabiz_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.SendToENabizLog_Class> SendToENabizLog(IList<string> PACKAGECODE, IList<SendToENabizEnum> STATUS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["SendToENabizLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));

            return TTReportNqlObject.QueryObjects<SendToENabiz.SendToENabizLog_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SendToENabiz.SendToENabizLog_Class> SendToENabizLog(TTObjectContext objectContext, IList<string> PACKAGECODE, IList<SendToENabizEnum> STATUS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["SendToENabizLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));

            return TTReportNqlObject.QueryObjects<SendToENabiz.SendToENabizLog_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SendToENabiz.GetNabizPackagesBySubepisode_Class> GetNabizPackagesBySubepisode(IList<string> PACKAGECODE, IList<SendToENabizEnum> STATUS, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetNabizPackagesBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetNabizPackagesBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetNabizPackagesBySubepisode_Class> GetNabizPackagesBySubepisode(TTObjectContext objectContext, IList<string> PACKAGECODE, IList<SendToENabizEnum> STATUS, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetNabizPackagesBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetNabizPackagesBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetEnabizPackagesByProtocolNo_Class> GetEnabizPackagesByProtocolNo(string PROTOCOLNO, IList<SendToENabizEnum> STATUS, IList<string> PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetEnabizPackagesByProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetEnabizPackagesByProtocolNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetEnabizPackagesByProtocolNo_Class> GetEnabizPackagesByProtocolNo(TTObjectContext objectContext, string PROTOCOLNO, IList<SendToENabizEnum> STATUS, IList<string> PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetEnabizPackagesByProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROTOCOLNO", PROTOCOLNO);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetEnabizPackagesByProtocolNo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetEnabizPackagesByPatientID_Class> GetEnabizPackagesByPatientID(IList<string> PACKAGECODE, Guid PATIENTID, IList<SendToENabizEnum> STATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetEnabizPackagesByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetEnabizPackagesByPatientID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetEnabizPackagesByPatientID_Class> GetEnabizPackagesByPatientID(TTObjectContext objectContext, IList<string> PACKAGECODE, Guid PATIENTID, IList<SendToENabizEnum> STATUS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetEnabizPackagesByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGECODE", PACKAGECODE);
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("STATUS", Globals.EnumListToIntList((IList)STATUS));

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetEnabizPackagesByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetPackagesByErrorCode_Class> GetPackagesByErrorCode(IList<string> RESPONSECODELIST, DateTime RECORDDATESTART, DateTime RECORDDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetPackagesByErrorCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESPONSECODELIST", RESPONSECODELIST);
            paramList.Add("RECORDDATESTART", RECORDDATESTART);
            paramList.Add("RECORDDATEEND", RECORDDATEEND);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetPackagesByErrorCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetPackagesByErrorCode_Class> GetPackagesByErrorCode(TTObjectContext objectContext, IList<string> RESPONSECODELIST, DateTime RECORDDATESTART, DateTime RECORDDATEEND, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetPackagesByErrorCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESPONSECODELIST", RESPONSECODELIST);
            paramList.Add("RECORDDATESTART", RECORDDATESTART);
            paramList.Add("RECORDDATEEND", RECORDDATEEND);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetPackagesByErrorCode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetPackageDetailsBySubepisode_Class> GetPackageDetailsBySubepisode(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetPackageDetailsBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetPackageDetailsBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetPackageDetailsBySubepisode_Class> GetPackageDetailsBySubepisode(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetPackageDetailsBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetPackageDetailsBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetCountOfSuccesPackageBySubepisode_Class> GetCountOfSuccesPackageBySubepisode(Guid SUBEPISODEID, string PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfSuccesPackageBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfSuccesPackageBySubepisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz.GetCountOfSuccesPackageBySubepisode_Class> GetCountOfSuccesPackageBySubepisode(TTObjectContext objectContext, Guid SUBEPISODEID, string PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetCountOfSuccesPackageBySubepisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<SendToENabiz.GetCountOfSuccesPackageBySubepisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SendToENabiz> GetBySubEpisodeAndPackage(TTObjectContext objectContext, Guid SUBEPISODE, string PACKAGECODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].QueryDefs["GetBySubEpisodeAndPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return ((ITTQuery)objectContext).QueryObjects<SendToENabiz>(queryDef, paramList);
        }

    /// <summary>
    /// Paket Kodu
    /// </summary>
        public string PackageCode
        {
            get { return (string)this["PACKAGECODE"]; }
            set { this["PACKAGECODE"] = value; }
        }

        public SendToENabizEnum? Status
        {
            get { return (SendToENabizEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Paket bazlı unique referans numarası
    /// </summary>
        public Guid? InternalObjectID
        {
            get { return (Guid?)this["INTERNALOBJECTID"]; }
            set { this["INTERNALOBJECTID"] = value; }
        }

        public string InternalObjectDefName
        {
            get { return (string)this["INTERNALOBJECTDEFNAME"]; }
            set { this["INTERNALOBJECTDEFNAME"] = value; }
        }

    /// <summary>
    /// Tabloya kayıt edildiği tarih
    /// </summary>
        public DateTime? RecordDate
        {
            get { return (DateTime?)this["RECORDDATE"]; }
            set { this["RECORDDATE"] = value; }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResponseOfENabizsCollection()
        {
            _ResponseOfENabizs = new ResponseOfENabiz.ChildResponseOfENabizCollection(this, new Guid("fc926d34-54d9-4278-953a-c0c8e0c375b9"));
            ((ITTChildObjectCollection)_ResponseOfENabizs).GetChildren();
        }

        protected ResponseOfENabiz.ChildResponseOfENabizCollection _ResponseOfENabizs = null;
        public ResponseOfENabiz.ChildResponseOfENabizCollection ResponseOfENabizs
        {
            get
            {
                if (_ResponseOfENabizs == null)
                    CreateResponseOfENabizsCollection();
                return _ResponseOfENabizs;
            }
        }

        protected SendToENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendToENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendToENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendToENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendToENabiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDTOENABIZ", dataRow) { }
        protected SendToENabiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDTOENABIZ", dataRow, isImported) { }
        public SendToENabiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendToENabiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendToENabiz() : base() { }

    }
}