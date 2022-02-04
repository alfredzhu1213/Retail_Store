using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Common
{
    /// <summary>
    /// 获取服务器硬件信息
    /// </summary>
    public static class HardwareInfo
    {
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCpuInfo()
        {
            //得到cpu信息 
            string cpuInfo = "";//cpu信息 
            try
            {
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();

                }
            }
            catch
            {
            }
            return cpuInfo;
        }

        /// <summary>
        /// 获取硬盘ID号
        /// </summary>
        /// <returns></returns>
        public static string GetHDInfo()
        {
            //获取硬盘ID 
            string HDInfo = "";
            try
            {
                ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDInfo = (string)mo.Properties["Model"].Value;
                }
            }
            catch
            {
            }
            return HDInfo;
        }

        /// <summary>
        /// 获取网卡硬件地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            //获取网卡硬件地址 
            string MacAddress = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        MacAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }
            catch
            {
            }
            return MacAddress;
        }
    }
}
