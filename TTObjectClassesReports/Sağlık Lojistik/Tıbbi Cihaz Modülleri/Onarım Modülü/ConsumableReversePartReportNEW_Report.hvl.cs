
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Sarf Edilen Yedek Parça / Malzeme Raporu
    /// </summary>
    public partial class ConsumableReversePartReportNEW : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ConsumableReversePartReportNEW MyParentReport
            {
                get { return (ConsumableReversePartReportNEW)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11121111 { get {return Header().NewField11121111;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField HOSPITAL11 { get {return Header().HOSPITAL11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public TTReportShape NewLine1221 { get {return Footer().NewLine1221;} }
            public TTReportShape NewLine1321 { get {return Footer().NewLine1321;} }
            public TTReportShape NewLine1421 { get {return Footer().NewLine1421;} }
            public TTReportShape NewLine1521 { get {return Footer().NewLine1521;} }
            public TTReportShape NewLine1621 { get {return Footer().NewLine1621;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public ConsumableReversePartReportNEW MyParentReport
                {
                    get { return (ConsumableReversePartReportNEW)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1211;
                public TTReportField NewField11121;
                public TTReportField NewField1311;
                public TTReportField NewField11111;
                public TTReportField NewField11121111;
                public TTReportField NewField112111;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField HOSPITAL11; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 22, 256, 40, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 13;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"BİYOMEDİKAL MÜHENDİSLİK MERKEZİ 

SARF EDİLEN YEDEK PARÇA / MALZEME RAPORU
";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 48, 19, 61, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 48, 41, 61, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"
İş İstek Nu";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 48, 166, 55, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Cihazın";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 55, 84, 61, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Adı";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 55, 125, 61, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Marka / Model";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 48, 207, 61, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"
Onarımı Yapan Teknisyen";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 48, 273, 61, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Kullanılan Yedek Parça / Malzeme

Adı / Cinsi - Maliyeti";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 36, 335, 42, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.Visible = EvetHayirEnum.ehHayir;
                    NewField11121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.TextFont.Size = 11;
                    NewField11121111.TextFont.Bold = true;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"Maliyeti";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 55, 166, 61, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"Deposu";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 40, 137, 45, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.TextFormat = @"Short Date";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"{@STARTDATE@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 40, 146, 45, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"-";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 40, 183, 45, false);
                    NewField17.Name = "NewField17";
                    NewField17.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField17.TextFormat = @"Short Date";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"{@ENDDATE@}";

                    HOSPITAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 10, 247, 20, false);
                    HOSPITAL11.Name = "HOSPITAL11";
                    HOSPITAL11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL11.TextFont.Name = "Arial";
                    HOSPITAL11.TextFont.Size = 13;
                    HOSPITAL11.TextFont.Bold = true;
                    HOSPITAL11.TextFont.CharSet = 162;
                    HOSPITAL11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField15.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    HOSPITAL11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField111211,NewField11,NewField111,NewField1111,NewField1211,NewField11121,NewField1311,NewField11111,NewField11121111,NewField112111,NewField15,NewField16,NewField17,HOSPITAL11};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if(((ConsumableReversePartReportNEW)ParentReport).RuntimeParameters.STORE == Guid.Empty)
                ((ConsumableReversePartReportNEW)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((ConsumableReversePartReportNEW)ParentReport).RuntimeParameters.STOREFLAG = 0;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ConsumableReversePartReportNEW MyParentReport
                {
                    get { return (ConsumableReversePartReportNEW)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportShape NewLine11;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1221;
                public TTReportShape NewLine1321;
                public TTReportShape NewLine1421;
                public TTReportShape NewLine1521;
                public TTReportShape NewLine1621;
                public TTReportShape NewLine131; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 155, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField12.Value = @"Bu Rapor {@printdate@} Tarihinde alınmıştır.";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 5, 273, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 207, 0, 207, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 5, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 125, 0, 125, 5, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 84, 0, 84, 5, false);
                    NewLine1321.Name = "NewLine1321";
                    NewLine1321.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1421 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 0, 41, 5, false);
                    NewLine1421.Name = "NewLine1421";
                    NewLine1421.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1521 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 5, false);
                    NewLine1521.Name = "NewLine1521";
                    NewLine1521.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1621 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 0, 9, 5, false);
                    NewLine1621.Name = "NewLine1621";
                    NewLine1621.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 273, 0, 273, 5, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = @"Bu Rapor " + DateTime.Now.ToShortDateString() + @" Tarihinde alınmıştır.";
                    return new TTReportObject[] { NewField12};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsumableReversePartReportNEW MyParentReport
            {
                get { return (ConsumableReversePartReportNEW)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField FAMNAME { get {return Body().FAMNAME;} }
            public TTReportField STORE { get {return Body().STORE;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField TEXT1 { get {return Body().TEXT1;} }
            public TTReportField TEXT2 { get {return Body().TEXT2;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine123 { get {return Body().NewLine123;} }
            public TTReportShape NewLine124 { get {return Body().NewLine124;} }
            public TTReportShape NewLine125 { get {return Body().NewLine125;} }
            public TTReportShape NewLine126 { get {return Body().NewLine126;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Repair.ConsumableReversePartReportQuery_Class>("ConsumableReversePartReportQuery2", Repair.ConsumableReversePartReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public ConsumableReversePartReportNEW MyParentReport
                {
                    get { return (ConsumableReversePartReportNEW)ParentReport; }
                }
                
                public TTReportField REQUESTNO;
                public TTReportField FAMNAME;
                public TTReportField STORE;
                public TTReportField RESPONSIBLEUSER;
                public TTReportField NewField1111;
                public TTReportField TEXT1;
                public TTReportField TEXT2;
                public TTReportField MARK;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportShape NewLine124;
                public TTReportShape NewLine125;
                public TTReportShape NewLine126;
                public TTReportShape NewLine13;
                public TTReportShape NewLine112;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 41, 10, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.NoClip = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Size = 9;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    FAMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 84, 10, false);
                    FAMNAME.Name = "FAMNAME";
                    FAMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAMNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FAMNAME.NoClip = EvetHayirEnum.ehEvet;
                    FAMNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FAMNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    FAMNAME.TextFont.Size = 9;
                    FAMNAME.TextFont.CharSet = 162;
                    FAMNAME.Value = @"{#FAMNAME#}";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 166, 10, false);
                    STORE.Name = "STORE";
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.MultiLine = EvetHayirEnum.ehEvet;
                    STORE.NoClip = EvetHayirEnum.ehEvet;
                    STORE.WordBreak = EvetHayirEnum.ehEvet;
                    STORE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STORE.ObjectDefName = "Store";
                    STORE.DataMember = "NAME";
                    STORE.TextFont.Size = 9;
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @"{#STORE#}";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 207, 10, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.NoClip = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.TextFont.Size = 9;
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"{#RESPONSIBLEUSER#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 19, 10, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"{@counter@}";

                    TEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 0, 272, 10, false);
                    TEXT1.Name = "TEXT1";
                    TEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1.NoClip = EvetHayirEnum.ehEvet;
                    TEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT1.TextFont.Size = 8;
                    TEXT1.TextFont.CharSet = 162;
                    TEXT1.Value = @"";

                    TEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 1, 365, 11, false);
                    TEXT2.Name = "TEXT2";
                    TEXT2.Visible = EvetHayirEnum.ehHayir;
                    TEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT2.NoClip = EvetHayirEnum.ehEvet;
                    TEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT2.TextFont.Size = 9;
                    TEXT2.TextFont.CharSet = 162;
                    TEXT2.Value = @"";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 125, 10, false);
                    MARK.Name = "MARK";
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.NoClip = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.ExpandTabs = EvetHayirEnum.ehEvet;
                    MARK.TextFont.Size = 9;
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARK#} / {#MODEL#}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 207, 0, 207, 11, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 10, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 125, 0, 125, 11, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 84, 0, 84, 11, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 0, 41, 11, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine124.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine125 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 11, false);
                    NewLine125.Name = "NewLine125";
                    NewLine125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine125.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine126 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 0, 9, 11, false);
                    NewLine126.Name = "NewLine126";
                    NewLine126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine126.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 273, 0, 273, 10, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 0, 273, 0, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 1, 334, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.ConsumableReversePartReportQuery_Class dataset_ConsumableReversePartReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Repair.ConsumableReversePartReportQuery_Class>(0);
                    REQUESTNO.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.RequestNo) : "");
                    FAMNAME.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.Famname) : "");
                    STORE.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.Store) : "");
                    STORE.PostFieldValueCalculation();
                    RESPONSIBLEUSER.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.Responsibleuser) : "");
                    NewField1111.CalcValue = ParentGroup.Counter.ToString();
                    TEXT1.CalcValue = @"";
                    TEXT2.CalcValue = @"";
                    MARK.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.Mark) : "") + @" / " + (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.Model) : "");
                    OBJECTID.CalcValue = (dataset_ConsumableReversePartReportQuery2 != null ? Globals.ToStringCore(dataset_ConsumableReversePartReportQuery2.ObjectID) : "");
                    return new TTReportObject[] { REQUESTNO,FAMNAME,STORE,RESPONSIBLEUSER,NewField1111,TEXT1,TEXT2,MARK,OBJECTID};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    //            string text1 = "";
//            string text2 = "";
//            TTObjectContext ctx = new TTObjectContext(true);
//            BindingList<Repair.ConsumableReversePartReportQueryNew_Class> material = Repair.ConsumableReversePartReportQueryNew(ctx,this.REQUESTNO.CalcValue);
//            foreach (Repair.ConsumableReversePartReportQueryNew_Class mt in material)
//            {
//                text1 += text1 + mt.Usedmaterial.ToString() + "\n";
//                text2 += text2 + mt.Amount.ToString() + "\n";
//            }
//            this.TEXT1.Value = text1;
//            this.TEXT2.Value = text2;
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (string.IsNullOrEmpty(this.FAMNAME.CalcValue))
            {
                Repair rep = (Repair)MyParentReport.ReportObjectContext.GetObject(new Guid(this.OBJECTID.CalcValue), typeof(Repair));
                if (rep is MaterialRepair)
                {
                    MaterialRepair mp = (MaterialRepair)rep;
                    this.FAMNAME.CalcValue = mp.FixedAssetDefinition.Name;
                }
                else
                    this.FAMNAME.CalcValue= rep.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
            }
            
            string text1 = "";
            string text2 = "";
            string text3 = "";
            TTObjectContext ctx = new TTObjectContext(true);
            BindingList<Repair.ConsumableReversePartReportQueryNew_Class> material = Repair.ConsumableReversePartReportQueryNew(ctx,this.REQUESTNO.CalcValue);
            foreach (Repair.ConsumableReversePartReportQueryNew_Class mt in material)
            {
                if(mt.Usedmaterial != null)
                    text1 = mt.Usedmaterial.ToString() + "   --  ";
                else
                    text1 = " "+ "  --  ";
               
                if(mt.Amount != null )
                    text2 = mt.Amount.ToString()+" TL " ;
                else
                    text2 = " ";
                
                text3+=text1+text2+"\n";
            }
            
            this.TEXT1.CalcValue = text3;
           // this.TEXT2.CalcValue = text2;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsumableReversePartReportNEW()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Deposu :", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            Name = "CONSUMABLEREVERSEPARTREPORTNEW";
            Caption = "Sarf Edilen Yedek Parça / Malzeme Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}