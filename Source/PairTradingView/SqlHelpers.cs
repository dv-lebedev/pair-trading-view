using System;
using Microsoft.Win32;

namespace PairTradingView
{
    public static class SqlHelpers
    {
        public static string[] GetSqlServerInstances()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            String[] instances = (String[])rk.GetValue("InstalledInstances");

            string[] values = null;

            if (instances.Length > 0)
            {
                values = new string[instances.Length];

                for (int i = 0; i < instances.Length; i++)
                {
                    if (instances[i] == "MSSQLSERVER")
                        values[i] = System.Environment.MachineName;
                    else
                        values[i] = System.Environment.MachineName + @"\" + instances[i];
                }
            }

            return values;
        }
    }
}
