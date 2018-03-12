// ***********************************************************************
// Assembly         : Communication
// Author           : zhiweiTechmqcp
// Created          : 08-08-2014
//
// Last Modified By : zhiweiTechmqcp
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="Class1.cs" company="ZHIWEI TECH">
//     Copyright (c) ZHIWEI TECH. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataHelper
{

    /// <summary>
    /// Class BytesCheck
    /// </summary>
    /// <remarks>SAP_SchoolSystem</remarks>
    public static class BytesCheck
    {
        //暂时放在此处

        /// <summary>
        /// Gets the card number.
        /// 转移至刷卡设备类方法
        /// </summary>
        /// <param name="dataIn">The data in.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <returns>System.String.</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        private static string GetCardNumber(StringBuilder dataIn, int startIndex, int endIndex)
        {
            string strReturn = "";
            if (dataIn.Length == 32)
            {
                var strBuff = new StringBuilder();
                for (int i = startIndex; i >= endIndex; i = i - 2)
                {
                    strBuff.Append(dataIn[i - 1]);
                    strBuff.Append(dataIn[i]);
                }
                strReturn = HEX_to_DEC(strBuff.ToString()).ToString();
            }
            return strReturn;
        }

        #region 编码转换

        /// <summary>
        /// HEs the x_to_ DEC.
        /// </summary>
        /// <param name="Hex">The hex.</param>
        /// <returns>System.Int64.</returns>
        private static long HEX_to_DEC(string Hex)
        {
            long num = 0;
            Hex = Hex.ToUpper();//转换为大写
            long num4 = Hex.Length;
            for (long i = 1L; i <= num4; i += 1L)
            {
                switch (Hex.Substring((int)(Hex.Length - i), 1))
                {
                    case "0":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 0.0)));
                        break;

                    case "1":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 1.0)));
                        break;

                    case "2":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 2.0)));
                        break;

                    case "3":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 3.0)));
                        break;

                    case "4":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 4.0)));
                        break;

                    case "5":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 5.0)));
                        break;

                    case "6":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 6.0)));
                        break;

                    case "7":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 7.0)));
                        break;

                    case "8":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 8.0)));
                        break;

                    case "9":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 9.0)));
                        break;

                    case "A":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 10.0)));
                        break;

                    case "B":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 11.0)));
                        break;

                    case "C":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 12.0)));
                        break;

                    case "D":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 13.0)));
                        break;

                    case "E":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 14.0)));
                        break;

                    case "F":
                        num = (long)Math.Round((double)(num + (Math.Pow(16.0, (double)(i - 1L)) * 15.0)));
                        break;
                }
            }
            return num;
        }

        #endregion 编码转换

        #region 桢格式(协议)

        /// <summary>
        /// Frames the format check.
        /// </summary>
        /// <param name="dataBey">The data bey.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private static bool FrameFormatCheck(int[] dataBey)
        {
            if (dataBey[0] == 170 && dataBey[1] == 204 && dataBey[19] == 238)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion 桢格式(协议)

        #region 校验和

        /// <summary>
        /// 计算按位异或校验和（返回校验和值）
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <returns>校验和值</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte GetXOR(byte[] Cmd)
        {
            byte check = (byte)(Cmd[0] ^ Cmd[1]);
            for (int i = 2; i < Cmd.Length; i++)
            {
                check = (byte)(check ^ Cmd[i]);
            }
            return check;
        }

        public static byte[] GetAnd(byte[] Cmd)
        {
            Int32 buff = Cmd.Aggregate(0, (current, b) => current + b);
            byte[] byteArray = new byte[2];
            byte[] byteVa = BitConverter.GetBytes(buff);
            byteArray[1] = byteVa[0];
            byteArray[0] = byteVa[1];
            return byteArray;
        }

        /// <summary>
        /// 和校验
        /// </summary>
        /// <param name="dataBey"></param>
        /// <returns></returns>
        private static bool AndCheck(int[] dataBey)
        {
            Int32 buff = 0;
            for (int i = 0; i < 17; i++)
            {
                buff = buff + dataBey[i];
            }
            byte[] byteArray = BitConverter.GetBytes(buff);
            if (dataBey[17] == byteArray[1] && dataBey[18] == byteArray[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 计算按位异或校验和（返回包含校验和的完整命令数组）
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <returns>包含校验和的完整命令数组</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte[] GetXORFull(byte[] Cmd)
        {
            byte check = GetXOR(Cmd);
            List<byte> newCmd = new List<byte>();
            newCmd.AddRange(Cmd);
            newCmd.Add(check);
            return newCmd.ToArray();
        }

        #endregion

        #region CRC16查表法

        #region CRC对应表

        //高位表  
        /// <summary>
        /// The CRC high
        /// </summary>
        readonly static byte[] CRCHigh = new byte[]{  
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,   
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,   
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,   
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,   
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,   
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,   
            0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,   
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,   
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,   
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,   
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,   
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,   
            0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,   
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,   
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40};
        //低位表  
        /// <summary>
        /// The CRC low
        /// </summary>
        readonly static byte[] CRCLow = new byte[]{  
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06,   
            0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD,   
            0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,   
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,   
            0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,   
            0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,   
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,   
            0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,   
            0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,   
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29,   
            0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED,   
            0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,   
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60,   
            0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67,   
            0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,   
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,   
            0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E,   
            0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,   
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71,   
            0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92,   
            0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,   
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B,   
            0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B,   
            0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,   
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42,   
            0x43, 0x83, 0x41, 0x81, 0x80, 0x40};
        #endregion

        /// <summary>
        /// 计算CRC16循环校验码
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns>高低位校验码</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte[] GetCRC16(byte[] Cmd, bool IsHighBefore)
        {
            int index;
            int crc_Low = 0xFF;
            int crc_High = 0xFF;
            for (int i = 0; i < Cmd.Length; i++)
            {
                index = crc_High ^ (char)Cmd[i];
                crc_High = crc_Low ^ CRCHigh[index];
                crc_Low = (byte)CRCLow[index];
            }
            if (IsHighBefore == true)
            {
                return new byte[2] { (byte)crc_High, (byte)crc_Low };
            }
            else
            {
                return new byte[2] { (byte)crc_Low, (byte)crc_High };
            }
        }

        /// <summary>
        /// 计算CRC16循环校验码（返回包含校验码的完整命令数组）
        /// </summary>
        /// <param name="Cmd">命令数组</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns>System.Byte[][].</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte[] GetCRC16Full(byte[] Cmd, bool IsHighBefore)
        {
            byte[] check = GetCRC16(Cmd, IsHighBefore);
            List<byte> newCmd = new List<byte>();
            newCmd.AddRange(Cmd);
            newCmd.AddRange(check);
            return newCmd.ToArray();
        }

        #endregion

        #region 多项式参数 CRC16计算

        /// <summary>
        /// 多项式参数 CRC16计算
        /// </summary>
        /// <param name="Cmd">命令</param>
        /// <param name="polynomial">多项式</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns>System.Byte[][].</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte[] GetCRC16ByPolynomial(byte[] Cmd, ushort polynomial, bool IsHighBefore)
        {
            byte[] CRC = new byte[2];
            ushort CRCValue = 0xFFFF;
            for (int i = 0; i < Cmd.Length; i++)
            {
                CRCValue = (ushort)(CRCValue ^ Cmd[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((CRCValue & 0x0001) != 0)
                    {
                        CRCValue = (ushort)((CRCValue >> 1) ^ polynomial);
                    }
                    else
                    {
                        CRCValue = (ushort)(CRCValue >> 1);
                    }
                }
            }
            byte[] Check = BitConverter.GetBytes(CRCValue);
            if (IsHighBefore == true)
            {
                return new byte[2] { Check[1], Check[0] };
            }
            else
            {
                return Check;
            }
        }

        /// <summary>
        /// 多项式参数 CRC16计算
        /// </summary>
        /// <param name="Cmd">命令</param>
        /// <param name="polynomial">多项式</param>
        /// <param name="IsHighBefore">高位是否在前</param>
        /// <returns>System.Byte[][].</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static byte[] GetCRC16ByPolynomialFull(byte[] Cmd, ushort polynomial, bool IsHighBefore)
        {
            byte[] check = GetCRC16ByPolynomial(Cmd, polynomial, IsHighBefore);
            List<byte> newCmd = new List<byte>();
            newCmd.AddRange(Cmd);
            newCmd.AddRange(check);
            return newCmd.ToArray();
        }

        #endregion
    }



}

