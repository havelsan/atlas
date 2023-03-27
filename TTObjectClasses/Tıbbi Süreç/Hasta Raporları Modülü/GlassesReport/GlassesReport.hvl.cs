
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GlassesReport")] 

    /// <summary>
    /// Gözlük Reçetesi
    /// </summary>
    public  partial class GlassesReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class GlassesReportList : TTObjectCollection<GlassesReport> { }
                    
        public class ChildGlassesReportCollection : TTObject.TTChildObjectCollection<GlassesReport>
        {
            public ChildGlassesReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGlassesReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGlassesReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SphRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHRIGHTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SphRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHRIGHTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SphRightPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHRIGHTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHRIGHTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SphLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHLEFTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SphLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHLEFTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SphLeftPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPHLEFTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["SPHLEFTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLLEFTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLLEFTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylLeftPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLLEFTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLLEFTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLRIGHTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLRIGHTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CylRightPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYLRIGHTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["CYLRIGHTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXLEFTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXLEFTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxLeftPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXLEFTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXLEFTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXRIGHTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXRIGHTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AxRightPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AXRIGHTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["AXRIGHTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISLEFTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISLEFTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisLeftPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISLEFTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISLEFTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISRIGHTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISRIGHTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrisRightPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRISRIGHTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PRISRIGHTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISLEFTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISLEFTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisLeftPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISLEFTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISLEFTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISRIGHTFAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISRIGHTNEAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BasisRightPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASISRIGHTPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BASISRIGHTPERMINENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GlassColorAndTypeEnum? GlassColorAndTypeFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORANDTYPEFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORANDTYPEFAR"].DataType;
                    return (GlassColorAndTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorAndTypeEnum? GlassColorAndTypeNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORANDTYPENEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORANDTYPENEAR"].DataType;
                    return (GlassColorAndTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorAndTypeEnum? GlassColorAndTypePerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORANDTYPEPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORANDTYPEPERMINENT"].DataType;
                    return (GlassColorAndTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? PupillerDistanceFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PUPILLERDISTANCEFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PUPILLERDISTANCEFAR"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? PupillerDistanceNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PUPILLERDISTANCENEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PUPILLERDISTANCENEAR"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? PupillerDistancePerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PUPILLERDISTANCEPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["PUPILLERDISTANCEPERMINENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? BorderFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BORDERFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BORDERFAR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BorderNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BORDERNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BORDERNEAR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BorderPerminent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BORDERPERMINENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["BORDERPERMINENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFBIRTH"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Relationship
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIONSHIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["RELATIONSHIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctormilclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORMILCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DiplomaRegisterNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMAREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GlassTypeEnum? GlassRightTypeFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSRIGHTTYPEFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSRIGHTTYPEFAR"].DataType;
                    return (GlassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassTypeEnum? GlassRightTypeNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSRIGHTTYPENEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSRIGHTTYPENEAR"].DataType;
                    return (GlassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassTypeEnum? GlassLeftTypeFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSLEFTTYPEFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSLEFTTYPEFAR"].DataType;
                    return (GlassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassTypeEnum? GlassLeftTypeNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSLEFTTYPENEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSLEFTTYPENEAR"].DataType;
                    return (GlassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorEnum? GlassColorRightFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORRIGHTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORRIGHTFAR"].DataType;
                    return (GlassColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorEnum? GlassColorRightNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORRIGHTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORRIGHTNEAR"].DataType;
                    return (GlassColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorEnum? GlassColorLeftFar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORLEFTFAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORLEFTFAR"].DataType;
                    return (GlassColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GlassColorEnum? GlassColorLeftNear
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GLASSCOLORLEFTNEAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].AllPropertyDefs["GLASSCOLORLEFTNEAR"].DataType;
                    return (GlassColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetGlassesReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGlassesReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGlassesReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("1565624c-b35c-46df-8b52-bf8a6c95c525"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("8d23a367-675d-4763-8325-dd27af06de26"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("04a412ff-63e8-44cd-b385-f30ab5897a4c"); } }
        }

        public static BindingList<GlassesReport.GetGlassesReport_Class> GetGlassesReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].QueryDefs["GetGlassesReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GlassesReport.GetGlassesReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GlassesReport.GetGlassesReport_Class> GetGlassesReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GLASSESREPORT"].QueryDefs["GetGlassesReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GlassesReport.GetGlassesReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Reçete Tipi
    /// </summary>
        public GlassesPrescriptionTypeEnum? PrescriptionType
        {
            get { return (GlassesPrescriptionTypeEnum?)(int?)this["PRESCRIPTIONTYPE"]; }
            set { this["PRESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Cam Tipi Sağ Uzak
    /// </summary>
        public GlassTypeEnum? GlassRightTypeFar
        {
            get { return (GlassTypeEnum?)(int?)this["GLASSRIGHTTYPEFAR"]; }
            set { this["GLASSRIGHTTYPEFAR"] = value; }
        }

    /// <summary>
    /// Cam Tipi Sol Uzak
    /// </summary>
        public GlassTypeEnum? GlassLeftTypeFar
        {
            get { return (GlassTypeEnum?)(int?)this["GLASSLEFTTYPEFAR"]; }
            set { this["GLASSLEFTTYPEFAR"] = value; }
        }

    /// <summary>
    /// Cam Tipi Sol Yakın
    /// </summary>
        public GlassTypeEnum? GlassLeftTypeNear
        {
            get { return (GlassTypeEnum?)(int?)this["GLASSLEFTTYPENEAR"]; }
            set { this["GLASSLEFTTYPENEAR"] = value; }
        }

    /// <summary>
    /// Cam Tipi Sağ Yakın
    /// </summary>
        public GlassTypeEnum? GlassRightTypeNear
        {
            get { return (GlassTypeEnum?)(int?)this["GLASSRIGHTTYPENEAR"]; }
            set { this["GLASSRIGHTTYPENEAR"] = value; }
        }

    /// <summary>
    /// Cam Rengi Sağ Uzak
    /// </summary>
        public GlassColorEnum? GlassColorRightFar
        {
            get { return (GlassColorEnum?)(int?)this["GLASSCOLORRIGHTFAR"]; }
            set { this["GLASSCOLORRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Cam Rengi Sağ Yakın
    /// </summary>
        public GlassColorEnum? GlassColorRightNear
        {
            get { return (GlassColorEnum?)(int?)this["GLASSCOLORRIGHTNEAR"]; }
            set { this["GLASSCOLORRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Cam Rengi Sol Uzak
    /// </summary>
        public GlassColorEnum? GlassColorLeftFar
        {
            get { return (GlassColorEnum?)(int?)this["GLASSCOLORLEFTFAR"]; }
            set { this["GLASSCOLORLEFTFAR"] = value; }
        }

    /// <summary>
    /// Cam Rengi Sol Yakın
    /// </summary>
        public GlassColorEnum? GlassColorLeftNear
        {
            get { return (GlassColorEnum?)(int?)this["GLASSCOLORLEFTNEAR"]; }
            set { this["GLASSCOLORLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sağ Uzak
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeRightFar
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPERIGHTFAR"]; }
            set { this["TELESKOPIKGLASSESTYPERIGHTFAR"] = value; }
        }

    /// <summary>
    /// Lens Geçici Madde
    /// </summary>
        public bool? TemporaryLens
        {
            get { return (bool?)this["TEMPORARYLENS"]; }
            set { this["TEMPORARYLENS"] = value; }
        }

    /// <summary>
    /// E-Reçete Numarası
    /// </summary>
        public string EReceteNo
        {
            get { return (string)this["ERECETENO"]; }
            set { this["ERECETENO"] = value; }
        }

    /// <summary>
    /// E-Reçete Tipi
    /// </summary>
        public MedulaOptikReceteTipiEnum? EReceteTipi
        {
            get { return (MedulaOptikReceteTipiEnum?)(int?)this["ERECETETIPI"]; }
            set { this["ERECETETIPI"] = value; }
        }

    /// <summary>
    /// Reçetedeki Teşhis alanı
    /// </summary>
        public string EReceteTeshis
        {
            get { return (string)this["ERECETETESHIS"]; }
            set { this["ERECETETESHIS"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sol Uzak
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeLeftFar
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPELEFTFAR"]; }
            set { this["TELESKOPIKGLASSESTYPELEFTFAR"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sol Yakın
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeLeftNear
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPELEFTNEAR"]; }
            set { this["TELESKOPIKGLASSESTYPELEFTNEAR"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sağ Yakın
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeRighNear
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPERIGHNEAR"]; }
            set { this["TELESKOPIKGLASSESTYPERIGHNEAR"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sağ Okuma
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeRighRead
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPERIGHREAD"]; }
            set { this["TELESKOPIKGLASSESTYPERIGHREAD"] = value; }
        }

    /// <summary>
    /// Teleskopik Gözlük Tipi Sol Okuma
    /// </summary>
        public TeleskopikGlassesTypeEnum? TeleskopikGlassesTypeLeftRead
        {
            get { return (TeleskopikGlassesTypeEnum?)(int?)this["TELESKOPIKGLASSESTYPELEFTREAD"]; }
            set { this["TELESKOPIKGLASSESTYPELEFTREAD"] = value; }
        }

    /// <summary>
    /// Çap Sağ Uzak
    /// </summary>
        public string DiameterRightFar
        {
            get { return (string)this["DIAMETERRIGHTFAR"]; }
            set { this["DIAMETERRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Çap Sol Uzak
    /// </summary>
        public string DiameterLeftFar
        {
            get { return (string)this["DIAMETERLEFTFAR"]; }
            set { this["DIAMETERLEFTFAR"] = value; }
        }

    /// <summary>
    /// Çap Sağ Yakın
    /// </summary>
        public string DiameterRightNear
        {
            get { return (string)this["DIAMETERRIGHTNEAR"]; }
            set { this["DIAMETERRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Çap Sol Yakın
    /// </summary>
        public string DiameterLeftNear
        {
            get { return (string)this["DIAMETERLEFTNEAR"]; }
            set { this["DIAMETERLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Eğim Sağ Uzak
    /// </summary>
        public string GradientRightFar
        {
            get { return (string)this["GRADIENTRIGHTFAR"]; }
            set { this["GRADIENTRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Eğim Sol Uzak
    /// </summary>
        public string GradientLeftFar
        {
            get { return (string)this["GRADIENTLEFTFAR"]; }
            set { this["GRADIENTLEFTFAR"] = value; }
        }

    /// <summary>
    /// Eğim Sağ Yakın
    /// </summary>
        public string GradientRightNear
        {
            get { return (string)this["GRADIENTRIGHTNEAR"]; }
            set { this["GRADIENTRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Eğim Sol Yakın
    /// </summary>
        public string GradientLeftNear
        {
            get { return (string)this["GRADIENTLEFTNEAR"]; }
            set { this["GRADIENTLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Sonuç Açıklaması
    /// </summary>
        public string SonucAciklamasi
        {
            get { return (string)this["SONUCACIKLAMASI"]; }
            set { this["SONUCACIKLAMASI"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string SonucKodu
        {
            get { return (string)this["SONUCKODU"]; }
            set { this["SONUCKODU"] = value; }
        }

    /// <summary>
    /// Yakın Çerçeve
    /// </summary>
        public bool? BorderNear
        {
            get { return (bool?)this["BORDERNEAR"]; }
            set { this["BORDERNEAR"] = value; }
        }

    /// <summary>
    /// Daimi Çerçeve
    /// </summary>
        public bool? BorderPerminent
        {
            get { return (bool?)this["BORDERPERMINENT"]; }
            set { this["BORDERPERMINENT"] = value; }
        }

    /// <summary>
    /// Sph Sağ Daimi
    /// </summary>
        public string SphRightPerminent
        {
            get { return (string)this["SPHRIGHTPERMINENT"]; }
            set { this["SPHRIGHTPERMINENT"] = value; }
        }

    /// <summary>
    /// Sph Sol Uzak
    /// </summary>
        public string SphLeftFar
        {
            get { return (string)this["SPHLEFTFAR"]; }
            set { this["SPHLEFTFAR"] = value; }
        }

    /// <summary>
    /// Sph Sol Yakın
    /// </summary>
        public string SphLeftNear
        {
            get { return (string)this["SPHLEFTNEAR"]; }
            set { this["SPHLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Sph Sol Daimi
    /// </summary>
        public string SphLeftPerminent
        {
            get { return (string)this["SPHLEFTPERMINENT"]; }
            set { this["SPHLEFTPERMINENT"] = value; }
        }

    /// <summary>
    /// Cyl Sol Uzak
    /// </summary>
        public string CylLeftFar
        {
            get { return (string)this["CYLLEFTFAR"]; }
            set { this["CYLLEFTFAR"] = value; }
        }

    /// <summary>
    /// Sph Sağ Uzak
    /// </summary>
        public string SphRightFar
        {
            get { return (string)this["SPHRIGHTFAR"]; }
            set { this["SPHRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Protocol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Cyl Sol Yakın
    /// </summary>
        public string CylLeftNear
        {
            get { return (string)this["CYLLEFTNEAR"]; }
            set { this["CYLLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Cyl Sol Daimi
    /// </summary>
        public string CylLeftPerminent
        {
            get { return (string)this["CYLLEFTPERMINENT"]; }
            set { this["CYLLEFTPERMINENT"] = value; }
        }

    /// <summary>
    /// Cyl Sağ Uzak
    /// </summary>
        public string CylRightFar
        {
            get { return (string)this["CYLRIGHTFAR"]; }
            set { this["CYLRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Cyl Sağ Yakın
    /// </summary>
        public string CylRightNear
        {
            get { return (string)this["CYLRIGHTNEAR"]; }
            set { this["CYLRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Cyl Sağ Daimi
    /// </summary>
        public string CylRightPerminent
        {
            get { return (string)this["CYLRIGHTPERMINENT"]; }
            set { this["CYLRIGHTPERMINENT"] = value; }
        }

    /// <summary>
    /// Ax Sol Uzak
    /// </summary>
        public string AxLeftFar
        {
            get { return (string)this["AXLEFTFAR"]; }
            set { this["AXLEFTFAR"] = value; }
        }

    /// <summary>
    /// Ax Sol Yakın
    /// </summary>
        public string AxLeftNear
        {
            get { return (string)this["AXLEFTNEAR"]; }
            set { this["AXLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Ax Sol Daimi
    /// </summary>
        public string AxLeftPerminent
        {
            get { return (string)this["AXLEFTPERMINENT"]; }
            set { this["AXLEFTPERMINENT"] = value; }
        }

    /// <summary>
    /// Sph Sağ Yakın
    /// </summary>
        public string SphRightNear
        {
            get { return (string)this["SPHRIGHTNEAR"]; }
            set { this["SPHRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Ax Sağ Uzak
    /// </summary>
        public string AxRightFar
        {
            get { return (string)this["AXRIGHTFAR"]; }
            set { this["AXRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Ax Sağ Yakın
    /// </summary>
        public string AxRightNear
        {
            get { return (string)this["AXRIGHTNEAR"]; }
            set { this["AXRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Ax Sağ Daimi
    /// </summary>
        public string AxRightPerminent
        {
            get { return (string)this["AXRIGHTPERMINENT"]; }
            set { this["AXRIGHTPERMINENT"] = value; }
        }

    /// <summary>
    /// Pris Sol Uzak
    /// </summary>
        public string PrisLeftFar
        {
            get { return (string)this["PRISLEFTFAR"]; }
            set { this["PRISLEFTFAR"] = value; }
        }

    /// <summary>
    /// Pris Sol Yakın
    /// </summary>
        public string PrisLeftNear
        {
            get { return (string)this["PRISLEFTNEAR"]; }
            set { this["PRISLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Pris Sol Daimi
    /// </summary>
        public string PrisLeftPerminent
        {
            get { return (string)this["PRISLEFTPERMINENT"]; }
            set { this["PRISLEFTPERMINENT"] = value; }
        }

    /// <summary>
    /// Pris Sağ Uzak
    /// </summary>
        public string PrisRightFar
        {
            get { return (string)this["PRISRIGHTFAR"]; }
            set { this["PRISRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Pris Sağ Yakın
    /// </summary>
        public string PrisRightNear
        {
            get { return (string)this["PRISRIGHTNEAR"]; }
            set { this["PRISRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Pris Sağ Daimi
    /// </summary>
        public string PrisRightPerminent
        {
            get { return (string)this["PRISRIGHTPERMINENT"]; }
            set { this["PRISRIGHTPERMINENT"] = value; }
        }

    /// <summary>
    /// Basis Sol Uzak
    /// </summary>
        public string BasisLeftFar
        {
            get { return (string)this["BASISLEFTFAR"]; }
            set { this["BASISLEFTFAR"] = value; }
        }

    /// <summary>
    /// Basis Sol Yakın
    /// </summary>
        public string BasisLeftNear
        {
            get { return (string)this["BASISLEFTNEAR"]; }
            set { this["BASISLEFTNEAR"] = value; }
        }

    /// <summary>
    /// Basis Sol Daimi
    /// </summary>
        public string BasisLeftPerminent
        {
            get { return (string)this["BASISLEFTPERMINENT"]; }
            set { this["BASISLEFTPERMINENT"] = value; }
        }

    /// <summary>
    /// Basis Sağ Uzak
    /// </summary>
        public string BasisRightFar
        {
            get { return (string)this["BASISRIGHTFAR"]; }
            set { this["BASISRIGHTFAR"] = value; }
        }

    /// <summary>
    /// Basis Sağ Yakın
    /// </summary>
        public string BasisRightNear
        {
            get { return (string)this["BASISRIGHTNEAR"]; }
            set { this["BASISRIGHTNEAR"] = value; }
        }

    /// <summary>
    /// Basis Sağ Daimi
    /// </summary>
        public string BasisRightPerminent
        {
            get { return (string)this["BASISRIGHTPERMINENT"]; }
            set { this["BASISRIGHTPERMINENT"] = value; }
        }

    /// <summary>
    /// Uzak Renk ve Cins
    /// </summary>
        public GlassColorAndTypeEnum? GlassColorAndTypeFar
        {
            get { return (GlassColorAndTypeEnum?)(int?)this["GLASSCOLORANDTYPEFAR"]; }
            set { this["GLASSCOLORANDTYPEFAR"] = value; }
        }

    /// <summary>
    /// Yakın Renk ve Cins
    /// </summary>
        public GlassColorAndTypeEnum? GlassColorAndTypeNear
        {
            get { return (GlassColorAndTypeEnum?)(int?)this["GLASSCOLORANDTYPENEAR"]; }
            set { this["GLASSCOLORANDTYPENEAR"] = value; }
        }

    /// <summary>
    /// Daimi Renk ve Cins
    /// </summary>
        public GlassColorAndTypeEnum? GlassColorAndTypePerminent
        {
            get { return (GlassColorAndTypeEnum?)(int?)this["GLASSCOLORANDTYPEPERMINENT"]; }
            set { this["GLASSCOLORANDTYPEPERMINENT"] = value; }
        }

    /// <summary>
    /// Uzak Pupiller Mesafe
    /// </summary>
        public double? PupillerDistanceFar
        {
            get { return (double?)this["PUPILLERDISTANCEFAR"]; }
            set { this["PUPILLERDISTANCEFAR"] = value; }
        }

    /// <summary>
    /// Yakın Pupiller Mesafe
    /// </summary>
        public double? PupillerDistanceNear
        {
            get { return (double?)this["PUPILLERDISTANCENEAR"]; }
            set { this["PUPILLERDISTANCENEAR"] = value; }
        }

    /// <summary>
    /// Daimi Pupiller Mesafe
    /// </summary>
        public double? PupillerDistancePerminent
        {
            get { return (double?)this["PUPILLERDISTANCEPERMINENT"]; }
            set { this["PUPILLERDISTANCEPERMINENT"] = value; }
        }

    /// <summary>
    /// Uzak Çerçeve
    /// </summary>
        public bool? BorderFar
        {
            get { return (bool?)this["BORDERFAR"]; }
            set { this["BORDERFAR"] = value; }
        }

        public bool? VitrumFar
        {
            get { return (bool?)this["VITRUMFAR"]; }
            set { this["VITRUMFAR"] = value; }
        }

    /// <summary>
    /// Yakın
    /// </summary>
        public bool? VitrumNear
        {
            get { return (bool?)this["VITRUMNEAR"]; }
            set { this["VITRUMNEAR"] = value; }
        }

    /// <summary>
    /// Yakın Okuma Kepi
    /// </summary>
        public bool? VitrumCloseReading
        {
            get { return (bool?)this["VITRUMCLOSEREADING"]; }
            set { this["VITRUMCLOSEREADING"] = value; }
        }

        protected GlassesReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GlassesReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GlassesReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GlassesReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GlassesReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GLASSESREPORT", dataRow) { }
        protected GlassesReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GLASSESREPORT", dataRow, isImported) { }
        public GlassesReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GlassesReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GlassesReport() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}