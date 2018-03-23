﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DataHelper
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]

    public struct WaveInCaps
    {
        public short wMid;

        public short wPid;

        public int vDriverVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]

        public string szPname;

        public int dwFormats;

        public short wChannels;

        public short wReserved1;
    }

    public struct netCard
    {
        public string Name;
        public string IPV4;
        public string IPV6;
        public string SubnetMask;
        public string Gateway;
        public string DNS;
    }

    public class deviceInfo
    {
        public Int64 TerminalID { get; set; }
        public string AliasName { get; set; }
        public string Type { get; set; }
        public string HardwareVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string SN { get; set; }

        public bool IsDHCP { get; set; }
        public string IPV4 { get; set; }
        public string SubnetMask { get; set; }
        public string Gateway { get; set; }
        public string DNS { get; set; }
        public String MAC { get; set; }
        public String IPV6 { get; set; }

        public bool IsOnLine { get; set; }
        public bool IsMulticastTo { get; set; }
        public String TaskStatus { get; set; }
        public bool SpeakBusy { get; set; }
        public String MonitorStatus { get; set; }
        public Int32 DefaultVolume { get; set; }
        public String ModeStr { get; set; }



        public deviceInfo() { }

    }


    public class SearchCmd
    {
        public string CMD;
        public string InquirersIPV4;

        public SearchCmd(string cmd, string ip)
        {
            CMD = cmd;
            InquirersIPV4 = ip;
        }
    }

    public class ChangeDevIPData
    {
        public string CMD = "ChangeNet";
        public string SN;
        public bool Switch;
        public string newIP;
        public string newmask;
        public string newgateway;
        public string newdnsweb;
        public string aliasName;
        public string userName;
        public string password;
    }

    public class SetIPResult
    {
        public bool Status;
        public int StatusCode;//
        public string SN;
        public string StatusMessage;// UserName or password error.
    }

    public class AuioRequestDev
    {
        public string SN;
        public int[] Groups;
        public AuioRequestDev() { }
        public AuioRequestDev(string sn, int[] groups)
        {
            SN = sn;
            Groups = groups;
        }
    }

    public class AuioRequests
    {
        public string CMD;
        public UInt32 Serial;
        public string CodingStandard;
        public AuioRequestDev[] Devices;

    }

    public class AuioRequest
    {
        public string CMD;
        public UInt32 Serial;
        public string CodingStandard;
        public AuioRequestDev Devices;
        public AuioRequest() { }
        public AuioRequest(string cmd, UInt32 serial, string codingStandard, AuioRequestDev devices)
        {
            CMD = cmd;
            Serial = serial;
            CodingStandard = codingStandard;
            Devices = devices;
        }
    }

    public class LoginDeviceResult
    {
        public bool Status;
        public int StatusCode;
        public string StatusMessage;
        public object DetailedInfo;
        public TokenData Data;
    }

    public class TokenData
    {
        public string Token;
    }

    public class GetCHGroupsResult
    {
        public bool Status;
        public int StatusCode;
        public string StatusMessage;
        public object DetailedInfo;
        public CHGroup[] Data;
    }

    public class CHGroup
    {
        public int GroupID;
        public string GroupName;
        public int[] ChannelList;
        public bool Status;
    }

    public class AuioRequestResult
    {
        public string Type;
        public string CMD;
        public bool Accept;
        public string SN;
        public UInt32 Serial;
        public UInt32 DelaySec;
    }

    public class AuioRequestEndResult
    {
        public string Type;
        public string CMD;
        public bool SpeakBusy;
        public UInt32 Serial;
        public AuioRequestDev Devices;
    }

    public class QueryPort
    {
        public string CMD;
        public string Channel;
        public UInt32 Serial;
        public QueryPort(UInt32 serial)
        {
            CMD = "QueryPort";
            Channel = "VoiceSpeak";
            Serial = serial;
        }
    }

    public class QueryPortResult
    {
        public string Type;
        public string CMD;
        public string SN;
        public UInt32 Serial;
        public UInt32 Port;
    }

    public class SetCommPort
    {
        public string CMD;
        public string Channel;
        public UInt32 Serial;
        public UInt32 Port;
        public AuioRequestDev[] Devices;
        public SetCommPort(UInt32 serial, UInt32 port, AuioRequestDev[] devices)
        {
            CMD = "SetCommPort";
            Channel = "VoiceSpeak";
            Serial = serial;
            Port = port;
            Devices = devices;
        }
    }

    public class SetCommPortResult
    {
        public string Type;
        public string CMD;
        public string Channel;
        public UInt32 Serial;
        public UInt32 Port;
    }

}