using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Moon.Orm;


namespace ZW_GBwin.Model
{

    [Table("[ZWGB_DbUpdateRecord]", DbType.Sqlite)]
    public class ZWGB_DbUpdateRecordSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_DbUpdateRecord]");
        }
        public static readonly FieldBase RID = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.OnlyPrimaryKey, "[RID]");
        public static readonly FieldBase VersionStr = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[VersionStr]");
        public static readonly FieldBase VersionNumber = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[VersionNumber]");
        public static readonly FieldBase SQLDDL1 = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[SQLDDL1]");
        public static readonly FieldBase SQLDDL2 = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[SQLDDL2]");
        public static readonly FieldBase SQLDDL3 = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[SQLDDL3]");
        public static readonly FieldBase IsSuccessful = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[IsSuccessful]");
        public static readonly FieldBase OperatingTime = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[OperatingTime]");
        public static readonly FieldBase Note = new FieldBase(DbType.Sqlite, "[ZWGB_DbUpdateRecord]", FieldType.Common, "[Note]");
    }

    [Table("[ZWGB_ResourceClass]", DbType.Sqlite)]
    public class ZWGB_ResourceClassSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_ResourceClass]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_ResourceClass]");
        }
        public static readonly FieldBase RID = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.OnlyPrimaryKey, "[RID]");
        public static readonly FieldBase ClassifyName = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[ClassifyName]");
        public static readonly FieldBase describe = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[describe]");
        public static readonly FieldBase Other = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[Other]");
        public static readonly FieldBase StorageLocation = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[StorageLocation]");
        public static readonly FieldBase IsAbsolutePath = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[IsAbsolutePath]");
        public static readonly FieldBase ObjectCount = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[ObjectCount]");
        public static readonly FieldBase ClassAlias = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[ClassAlias]");
        public static readonly FieldBase IsShare = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceClass]", FieldType.Common, "[IsShare]");
    }

    [Table("[ZWGB_ResourceFiles]", DbType.Sqlite)]
    public class ZWGB_ResourceFilesSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_ResourceFiles]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_ResourceFiles]");
        }
        public static readonly FieldBase RID = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.OnlyPrimaryKey, "[RID]");
        public static readonly FieldBase FileName = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[FileName]");
        public static readonly FieldBase FileType = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[FileType]");
        public static readonly FieldBase ImportDate = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[ImportDate]");
        public static readonly FieldBase ResourceClass = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[ResourceClass]");
        public static readonly FieldBase Describe = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[Describe]");
        public static readonly FieldBase IsExist = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[IsExist]");
        public static readonly FieldBase IsUsed = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[IsUsed]");
        public static readonly FieldBase UsedCount = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[UsedCount]");
        public static readonly FieldBase DurationTime = new FieldBase(DbType.Sqlite, "[ZWGB_ResourceFiles]", FieldType.Common, "[DurationTime]");
    }

    [Table("[ZWGB_Plans]", DbType.Sqlite)]
    public class ZWGB_PlansSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_Plans]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_Plans]");
        }
        public static readonly FieldBase PID = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.OnlyPrimaryKey, "[PID]");
        public static readonly FieldBase PlanName = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[PlanName]");
        public static readonly FieldBase PlanDescribe = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[PlanDescribe]");
        public static readonly FieldBase IsCurrent = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[IsCurrent]");
        public static readonly FieldBase AttManageId = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[AttManageId]");
        public static readonly FieldBase MediaTemplateId = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[MediaTemplateId]");
        public static readonly FieldBase DisplayColor = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[DisplayColor]");
        public static readonly FieldBase ImageIndex = new FieldBase(DbType.Sqlite, "[ZWGB_Plans]", FieldType.Common, "[ImageIndex]");
    }

    [Table("[ZWGB_PlayTask]", DbType.Sqlite)]
    public class ZWGB_PlayTaskSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_PlayTask]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_PlayTask]");
        }
        public static readonly FieldBase TaskID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.OnlyPrimaryKey, "[TaskID]");
        public static readonly FieldBase PlanID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[PlanID]");
        public static readonly FieldBase TaskName = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[TaskName]");
        public static readonly FieldBase StarTime = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[StarTime]");
        public static readonly FieldBase EndTime = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[EndTime]");
        public static readonly FieldBase SpanSeconds = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[SpanSeconds]");
        public static readonly FieldBase ImageIndex = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[ImageIndex]");
        public static readonly FieldBase DisplayColor = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[DisplayColor]");
        public static readonly FieldBase PlayMode = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[PlayMode]");
        public static readonly FieldBase IsMonday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsMonday]");
        public static readonly FieldBase IsTuesday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsTuesday]");
        public static readonly FieldBase IsWednesday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsWednesday]");
        public static readonly FieldBase IsThursday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsThursday]");
        public static readonly FieldBase IsFriday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsFriday]");
        public static readonly FieldBase IsSaturday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsSaturday]");
        public static readonly FieldBase IsSunday = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsSunday]");
        public static readonly FieldBase StarVolume = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[StarVolume]");
        public static readonly FieldBase EndVolume = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[EndVolume]");
        public static readonly FieldBase Describe = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[Describe]");
        public static readonly FieldBase IsTemp = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsTemp]");
        public static readonly FieldBase StarTimeStr = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[StarTimeStr]");
        public static readonly FieldBase EndTimeStr = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[EndTimeStr]");
        public static readonly FieldBase SpanTimeStr = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[SpanTimeStr]");
        public static readonly FieldBase Type = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[Type]");
        public static readonly FieldBase Remarks = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[Remarks]");
        public static readonly FieldBase AreaID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[AreaID]");
        public static readonly FieldBase IsPlayList = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[IsPlayList]");
        public static readonly FieldBase PlayListId = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[PlayListId]");
        public static readonly FieldBase PlayOrder = new FieldBase(DbType.Sqlite, "[ZWGB_PlayTask]", FieldType.Common, "[PlayOrder]");
    }

    [Table("[ZWGB_PlayFileProject]", DbType.Sqlite)]
    public class ZWGB_PlayFileProjectSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_PlayFileProject]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_PlayFileProject]");
        }
        public static readonly FieldBase ProjectID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.OnlyPrimaryKey, "[ProjectID]");
        public static readonly FieldBase TaskID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[TaskID]");
        public static readonly FieldBase Serial = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[Serial]");
        public static readonly FieldBase ProjectType = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[ProjectType]");
        public static readonly FieldBase FileRID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[FileRID]");
        public static readonly FieldBase StarVolume = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[StarVolume]");
        public static readonly FieldBase EndVolume = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[EndVolume]");
        public static readonly FieldBase Singer = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[Singer]");
        public static readonly FieldBase PathName = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[PathName]");
        public static readonly FieldBase SpanSeconds = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[SpanSeconds]");
        public static readonly FieldBase IsAbsolutePath = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[IsAbsolutePath]");
        public static readonly FieldBase DisplayColor = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[DisplayColor]");
        public static readonly FieldBase ImageIndex = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[ImageIndex]");
        public static readonly FieldBase SpanTimeStr = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[SpanTimeStr]");
        public static readonly FieldBase FileName = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileProject]", FieldType.Common, "[FileName]");
    }

    [Table("[ZWGB_TerminalDev]", DbType.Sqlite)]
    public class ZWGB_TerminalDevSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_TerminalDev]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_TerminalDev]");
        }
        public static readonly FieldBase TerminalID = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.OnlyPrimaryKey, "[TerminalID]");
        public static readonly FieldBase AliasName = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[AliasName]");
        public static readonly FieldBase Type = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[Type]");
        public static readonly FieldBase SN = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[SN]");
        public static readonly FieldBase ModeStr = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[ModeStr]");
        public static readonly FieldBase MAC = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[MAC]");
        public static readonly FieldBase IPV4 = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[IPV4]");
        public static readonly FieldBase SubnetMask = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[SubnetMask]");
        public static readonly FieldBase Gateway = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[Gateway]");
        public static readonly FieldBase DNS = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[DNS]");
        public static readonly FieldBase IPV6 = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[IPV6]");
        public static readonly FieldBase IsMulticastTo = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[IsMulticastTo]");
        public static readonly FieldBase IsOnLine = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[IsOnLine]");
        public static readonly FieldBase IsDHCP = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[IsDHCP]");
        public static readonly FieldBase TaskStatus = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[TaskStatus]");
        public static readonly FieldBase MonitorStatus = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[MonitorStatus]");
        public static readonly FieldBase FirmwareVersion = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[FirmwareVersion]");
        public static readonly FieldBase HardwareVersion = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[HardwareVersion]");
        public static readonly FieldBase DefaultVolume = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[DefaultVolume]");
        public static readonly FieldBase AreaID = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[AreaID]");
        public static readonly FieldBase Channals = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalDev]", FieldType.Common, "[Channals]");
    }

    [Table("[ZWGB_TerminalGroup]", DbType.Sqlite)]
    public class ZWGB_TerminalGroupSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_TerminalGroup]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_TerminalGroup]");
        }
        public static readonly FieldBase GID = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalGroup]", FieldType.OnlyPrimaryKey, "[GID]");
        public static readonly FieldBase GroupID = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalGroup]", FieldType.Common, "[GroupID]");
        public static readonly FieldBase GroupName = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalGroup]", FieldType.Common, "[GroupName]");
        public static readonly FieldBase TerminalID = new FieldBase(DbType.Sqlite, "[ZWGB_TerminalGroup]", FieldType.Common, "[TerminalID]");
    }

    [Table("[ZWGB_PlayFileSync]", DbType.Sqlite)]
    public class ZWGB_PlayFileSyncSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_PlayFileSync]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_PlayFileSync]");
        }
        public static readonly FieldBase SyncID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.OnlyPrimaryKey, "[SyncID]");
        public static readonly FieldBase APID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.Common, "[APID]");
        public static readonly FieldBase TerminalID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.Common, "[TerminalID]");
        public static readonly FieldBase IsSync = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.Common, "[IsSync]");
        public static readonly FieldBase ProjectID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.Common, "[ProjectID]");
        public static readonly FieldBase FileRID = new FieldBase(DbType.Sqlite, "[ZWGB_PlayFileSync]", FieldType.Common, "[FileRID]");
    }

    [Table("[ZWGB_Area]", DbType.Sqlite)]
    public class ZWGB_AreaSet : MQLBase
    {
        public static new MQLBase Select(params FieldBase[] fields)
        {
            return MQLBase.Select(DbType.Sqlite, "[ZWGB_Area]", fields);
        }
        public static new MQLBase SelectAll()
        {
            return MQLBase.SelectAll(DbType.Sqlite, "[ZWGB_Area]");
        }
        public static readonly FieldBase AreaID = new FieldBase(DbType.Sqlite, "[ZWGB_Area]", FieldType.OnlyPrimaryKey, "[AreaID]");
        public static readonly FieldBase AreaName = new FieldBase(DbType.Sqlite, "[ZWGB_Area]", FieldType.Common, "[AreaName]");
        public static readonly FieldBase ParentAreaID = new FieldBase(DbType.Sqlite, "[ZWGB_Area]", FieldType.Common, "[ParentAreaID]");
        public static readonly FieldBase DefaultVolume = new FieldBase(DbType.Sqlite, "[ZWGB_Area]", FieldType.Common, "[DefaultVolume]");
    }


    [Table("[ZWGB_DbUpdateRecord]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "RID")]
    public class ZWGB_DbUpdateRecord : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 RID
        {
            get { return GetPropertyValue<Int64>("RID"); }
            set { SetPropertyValue("RID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String VersionStr
        {
            get { return GetPropertyValue<String>("VersionStr"); }
            set { SetPropertyValue("VersionStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Double VersionNumber
        {
            get { return GetPropertyValue<Double>("VersionNumber"); }
            set { SetPropertyValue("VersionNumber", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SQLDDL1
        {
            get { return GetPropertyValue<String>("SQLDDL1"); }
            set { SetPropertyValue("SQLDDL1", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SQLDDL2
        {
            get { return GetPropertyValue<String>("SQLDDL2"); }
            set { SetPropertyValue("SQLDDL2", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SQLDDL3
        {
            get { return GetPropertyValue<String>("SQLDDL3"); }
            set { SetPropertyValue("SQLDDL3", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSuccessful
        {
            get { return GetPropertyValue<Boolean>("IsSuccessful"); }
            set { SetPropertyValue("IsSuccessful", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OperatingTime
        {
            get { return GetPropertyValue<DateTime>("OperatingTime"); }
            set { SetPropertyValue("OperatingTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Note
        {
            get { return GetPropertyValue<String>("Note"); }
            set { SetPropertyValue("Note", value); }
        }
    }

    [Table("[ZWGB_ResourceClass]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "RID")]
    public class ZWGB_ResourceClass : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 RID
        {
            get { return GetPropertyValue<Int64>("RID"); }
            set { SetPropertyValue("RID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ClassifyName
        {
            get { return GetPropertyValue<String>("ClassifyName"); }
            set { SetPropertyValue("ClassifyName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String describe
        {
            get { return GetPropertyValue<String>("describe"); }
            set { SetPropertyValue("describe", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Other
        {
            get { return GetPropertyValue<String>("Other"); }
            set { SetPropertyValue("Other", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String StorageLocation
        {
            get { return GetPropertyValue<String>("StorageLocation"); }
            set { SetPropertyValue("StorageLocation", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsAbsolutePath
        {
            get { return GetPropertyValue<Boolean>("IsAbsolutePath"); }
            set { SetPropertyValue("IsAbsolutePath", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ObjectCount
        {
            get { return GetPropertyValue<Int32>("ObjectCount"); }
            set { SetPropertyValue("ObjectCount", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ClassAlias
        {
            get { return GetPropertyValue<String>("ClassAlias"); }
            set { SetPropertyValue("ClassAlias", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsShare
        {
            get { return GetPropertyValue<Boolean>("IsShare"); }
            set { SetPropertyValue("IsShare", value); }
        }
    }

    [Table("[ZWGB_ResourceFiles]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "RID")]
    public class ZWGB_ResourceFiles : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 RID
        {
            get { return GetPropertyValue<Int64>("RID"); }
            set { SetPropertyValue("RID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FileName
        {
            get { return GetPropertyValue<String>("FileName"); }
            set { SetPropertyValue("FileName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FileType
        {
            get { return GetPropertyValue<String>("FileType"); }
            set { SetPropertyValue("FileType", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ImportDate
        {
            get { return GetPropertyValue<DateTime>("ImportDate"); }
            set { SetPropertyValue("ImportDate", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ResourceClass
        {
            get { return GetPropertyValue<Int64>("ResourceClass"); }
            set { SetPropertyValue("ResourceClass", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Describe
        {
            get { return GetPropertyValue<String>("Describe"); }
            set { SetPropertyValue("Describe", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsExist
        {
            get { return GetPropertyValue<Boolean>("IsExist"); }
            set { SetPropertyValue("IsExist", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsUsed
        {
            get { return GetPropertyValue<Boolean>("IsUsed"); }
            set { SetPropertyValue("IsUsed", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 UsedCount
        {
            get { return GetPropertyValue<Int32>("UsedCount"); }
            set { SetPropertyValue("UsedCount", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String DurationTime
        {
            get { return GetPropertyValue<String>("DurationTime"); }
            set { SetPropertyValue("DurationTime", value); }
        }
    }

    [Table("[ZWGB_Plans]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "PID")]
    public class ZWGB_Plans : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 PID
        {
            get { return GetPropertyValue<Int64>("PID"); }
            set { SetPropertyValue("PID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PlanName
        {
            get { return GetPropertyValue<String>("PlanName"); }
            set { SetPropertyValue("PlanName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PlanDescribe
        {
            get { return GetPropertyValue<String>("PlanDescribe"); }
            set { SetPropertyValue("PlanDescribe", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsCurrent
        {
            get { return GetPropertyValue<Boolean>("IsCurrent"); }
            set { SetPropertyValue("IsCurrent", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 AttManageId
        {
            get { return GetPropertyValue<Int64>("AttManageId"); }
            set { SetPropertyValue("AttManageId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 MediaTemplateId
        {
            get { return GetPropertyValue<Int64>("MediaTemplateId"); }
            set { SetPropertyValue("MediaTemplateId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DisplayColor
        {
            get { return GetPropertyValue<Int32>("DisplayColor"); }
            set { SetPropertyValue("DisplayColor", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ImageIndex
        {
            get { return GetPropertyValue<Int32>("ImageIndex"); }
            set { SetPropertyValue("ImageIndex", value); }
        }
    }

    [Table("[ZWGB_PlayTask]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "TaskID")]
    public class ZWGB_PlayTask : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 TaskID
        {
            get { return GetPropertyValue<Int64>("TaskID"); }
            set { SetPropertyValue("TaskID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 PlanID
        {
            get { return GetPropertyValue<Int64>("PlanID"); }
            set { SetPropertyValue("PlanID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String TaskName
        {
            get { return GetPropertyValue<String>("TaskName"); }
            set { SetPropertyValue("TaskName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StarTime
        {
            get { return GetPropertyValue<DateTime>("StarTime"); }
            set { SetPropertyValue("StarTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            get { return GetPropertyValue<DateTime>("EndTime"); }
            set { SetPropertyValue("EndTime", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 SpanSeconds
        {
            get { return GetPropertyValue<Int64>("SpanSeconds"); }
            set { SetPropertyValue("SpanSeconds", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ImageIndex
        {
            get { return GetPropertyValue<Int32>("ImageIndex"); }
            set { SetPropertyValue("ImageIndex", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DisplayColor
        {
            get { return GetPropertyValue<Int32>("DisplayColor"); }
            set { SetPropertyValue("DisplayColor", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PlayMode
        {
            get { return GetPropertyValue<String>("PlayMode"); }
            set { SetPropertyValue("PlayMode", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsMonday
        {
            get { return GetPropertyValue<Boolean>("IsMonday"); }
            set { SetPropertyValue("IsMonday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsTuesday
        {
            get { return GetPropertyValue<Boolean>("IsTuesday"); }
            set { SetPropertyValue("IsTuesday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsWednesday
        {
            get { return GetPropertyValue<Boolean>("IsWednesday"); }
            set { SetPropertyValue("IsWednesday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsThursday
        {
            get { return GetPropertyValue<Boolean>("IsThursday"); }
            set { SetPropertyValue("IsThursday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsFriday
        {
            get { return GetPropertyValue<Boolean>("IsFriday"); }
            set { SetPropertyValue("IsFriday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSaturday
        {
            get { return GetPropertyValue<Boolean>("IsSaturday"); }
            set { SetPropertyValue("IsSaturday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSunday
        {
            get { return GetPropertyValue<Boolean>("IsSunday"); }
            set { SetPropertyValue("IsSunday", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 StarVolume
        {
            get { return GetPropertyValue<Int32>("StarVolume"); }
            set { SetPropertyValue("StarVolume", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 EndVolume
        {
            get { return GetPropertyValue<Int32>("EndVolume"); }
            set { SetPropertyValue("EndVolume", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Describe
        {
            get { return GetPropertyValue<String>("Describe"); }
            set { SetPropertyValue("Describe", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsTemp
        {
            get { return GetPropertyValue<Boolean>("IsTemp"); }
            set { SetPropertyValue("IsTemp", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String StarTimeStr
        {
            get { return GetPropertyValue<String>("StarTimeStr"); }
            set { SetPropertyValue("StarTimeStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String EndTimeStr
        {
            get { return GetPropertyValue<String>("EndTimeStr"); }
            set { SetPropertyValue("EndTimeStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SpanTimeStr
        {
            get { return GetPropertyValue<String>("SpanTimeStr"); }
            set { SetPropertyValue("SpanTimeStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Type
        {
            get { return GetPropertyValue<Int32>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Remarks
        {
            get { return GetPropertyValue<String>("Remarks"); }
            set { SetPropertyValue("Remarks", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 AreaID
        {
            get { return GetPropertyValue<Int32>("AreaID"); }
            set { SetPropertyValue("AreaID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsPlayList
        {
            get { return GetPropertyValue<Boolean>("IsPlayList"); }
            set { SetPropertyValue("IsPlayList", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 PlayListId
        {
            get { return GetPropertyValue<Int32>("PlayListId"); }
            set { SetPropertyValue("PlayListId", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 PlayOrder
        {
            get { return GetPropertyValue<Int32>("PlayOrder"); }
            set { SetPropertyValue("PlayOrder", value); }
        }
    }

    [Table("[ZWGB_PlayFileProject]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "ProjectID")]
    public class ZWGB_PlayFileProject : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 ProjectID
        {
            get { return GetPropertyValue<Int64>("ProjectID"); }
            set { SetPropertyValue("ProjectID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 TaskID
        {
            get { return GetPropertyValue<Int64>("TaskID"); }
            set { SetPropertyValue("TaskID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Serial
        {
            get { return GetPropertyValue<Int32>("Serial"); }
            set { SetPropertyValue("Serial", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ProjectType
        {
            get { return GetPropertyValue<String>("ProjectType"); }
            set { SetPropertyValue("ProjectType", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 FileRID
        {
            get { return GetPropertyValue<Int64>("FileRID"); }
            set { SetPropertyValue("FileRID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 StarVolume
        {
            get { return GetPropertyValue<Int32>("StarVolume"); }
            set { SetPropertyValue("StarVolume", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 EndVolume
        {
            get { return GetPropertyValue<Int32>("EndVolume"); }
            set { SetPropertyValue("EndVolume", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Singer
        {
            get { return GetPropertyValue<String>("Singer"); }
            set { SetPropertyValue("Singer", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String PathName
        {
            get { return GetPropertyValue<String>("PathName"); }
            set { SetPropertyValue("PathName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 SpanSeconds
        {
            get { return GetPropertyValue<Int32>("SpanSeconds"); }
            set { SetPropertyValue("SpanSeconds", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsAbsolutePath
        {
            get { return GetPropertyValue<Boolean>("IsAbsolutePath"); }
            set { SetPropertyValue("IsAbsolutePath", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DisplayColor
        {
            get { return GetPropertyValue<Int32>("DisplayColor"); }
            set { SetPropertyValue("DisplayColor", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ImageIndex
        {
            get { return GetPropertyValue<Int32>("ImageIndex"); }
            set { SetPropertyValue("ImageIndex", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SpanTimeStr
        {
            get { return GetPropertyValue<String>("SpanTimeStr"); }
            set { SetPropertyValue("SpanTimeStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FileName
        {
            get { return GetPropertyValue<String>("FileName"); }
            set { SetPropertyValue("FileName", value); }
        }
    }

    [Table("[ZWGB_TerminalDev]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "TerminalID")]
    public class ZWGB_TerminalDev : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 TerminalID
        {
            get { return GetPropertyValue<Int64>("TerminalID"); }
            set { SetPropertyValue("TerminalID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String AliasName
        {
            get { return GetPropertyValue<String>("AliasName"); }
            set { SetPropertyValue("AliasName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Type
        {
            get { return GetPropertyValue<String>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SN
        {
            get { return GetPropertyValue<String>("SN"); }
            set { SetPropertyValue("SN", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ModeStr
        {
            get { return GetPropertyValue<String>("ModeStr"); }
            set { SetPropertyValue("ModeStr", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String MAC
        {
            get { return GetPropertyValue<String>("MAC"); }
            set { SetPropertyValue("MAC", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String IPV4
        {
            get { return GetPropertyValue<String>("IPV4"); }
            set { SetPropertyValue("IPV4", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SubnetMask
        {
            get { return GetPropertyValue<String>("SubnetMask"); }
            set { SetPropertyValue("SubnetMask", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Gateway
        {
            get { return GetPropertyValue<String>("Gateway"); }
            set { SetPropertyValue("Gateway", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String DNS
        {
            get { return GetPropertyValue<String>("DNS"); }
            set { SetPropertyValue("DNS", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String IPV6
        {
            get { return GetPropertyValue<String>("IPV6"); }
            set { SetPropertyValue("IPV6", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsMulticastTo
        {
            get { return GetPropertyValue<Boolean>("IsMulticastTo"); }
            set { SetPropertyValue("IsMulticastTo", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsOnLine
        {
            get { return GetPropertyValue<Boolean>("IsOnLine"); }
            set { SetPropertyValue("IsOnLine", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsDHCP
        {
            get { return GetPropertyValue<Boolean>("IsDHCP"); }
            set { SetPropertyValue("IsDHCP", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String TaskStatus
        {
            get { return GetPropertyValue<String>("TaskStatus"); }
            set { SetPropertyValue("TaskStatus", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String MonitorStatus
        {
            get { return GetPropertyValue<String>("MonitorStatus"); }
            set { SetPropertyValue("MonitorStatus", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FirmwareVersion
        {
            get { return GetPropertyValue<String>("FirmwareVersion"); }
            set { SetPropertyValue("FirmwareVersion", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String HardwareVersion
        {
            get { return GetPropertyValue<String>("HardwareVersion"); }
            set { SetPropertyValue("HardwareVersion", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DefaultVolume
        {
            get { return GetPropertyValue<Int32>("DefaultVolume"); }
            set { SetPropertyValue("DefaultVolume", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 AreaID
        {
            get { return GetPropertyValue<Int64>("AreaID"); }
            set { SetPropertyValue("AreaID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Channals
        {
            get { return GetPropertyValue<Int32>("Channals"); }
            set { SetPropertyValue("Channals", value); }
        }
    }

    [Table("[ZWGB_TerminalGroup]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "GID")]
    public class ZWGB_TerminalGroup : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 GID
        {
            get { return GetPropertyValue<Int64>("GID"); }
            set { SetPropertyValue("GID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 GroupID
        {
            get { return GetPropertyValue<Int64>("GroupID"); }
            set { SetPropertyValue("GroupID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String GroupName
        {
            get { return GetPropertyValue<String>("GroupName"); }
            set { SetPropertyValue("GroupName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 TerminalID
        {
            get { return GetPropertyValue<Int64>("TerminalID"); }
            set { SetPropertyValue("TerminalID", value); }
        }
    }

    [Table("[ZWGB_PlayFileSync]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "SyncID")]
    public class ZWGB_PlayFileSync : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 SyncID
        {
            get { return GetPropertyValue<Int64>("SyncID"); }
            set { SetPropertyValue("SyncID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 APID
        {
            get { return GetPropertyValue<Int64>("APID"); }
            set { SetPropertyValue("APID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 TerminalID
        {
            get { return GetPropertyValue<Int32>("TerminalID"); }
            set { SetPropertyValue("TerminalID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSync
        {
            get { return GetPropertyValue<Boolean>("IsSync"); }
            set { SetPropertyValue("IsSync", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ProjectID
        {
            get { return GetPropertyValue<Int64>("ProjectID"); }
            set { SetPropertyValue("ProjectID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 FileRID
        {
            get { return GetPropertyValue<Int64>("FileRID"); }
            set { SetPropertyValue("FileRID", value); }
        }
    }

    [Table("[ZWGB_Area]", DbType.Sqlite)]
    [TablesPrimaryKey(PrimaryKeyType.CustomerGUID, typeof(Int64), "AreaID")]
    public class ZWGB_Area : EntityBase
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 AreaID
        {
            get { return GetPropertyValue<Int64>("AreaID"); }
            set { SetPropertyValue("AreaID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public String AreaName
        {
            get { return GetPropertyValue<String>("AreaName"); }
            set { SetPropertyValue("AreaName", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 ParentAreaID
        {
            get { return GetPropertyValue<Int64>("ParentAreaID"); }
            set { SetPropertyValue("ParentAreaID", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DefaultVolume
        {
            get { return GetPropertyValue<Int32>("DefaultVolume"); }
            set { SetPropertyValue("DefaultVolume", value); }
        }
    }


}