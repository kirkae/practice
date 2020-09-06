using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace StudentManageForm
{
    public class CommandInfo
    {
        public string CommandText;
        public DbParameter[] Parameters;
        public bool IsProc;

        public CommandInfo()
        {

        }

        public CommandInfo(string comText, bool isProc)
        {
            this.CommandText = comText;
            this.IsProc = isProc;
        }

        public CommandInfo(string sqlText,bool isProc,DbParameter[] para)
        {
            this.CommandText = sqlText;
            this.IsProc = isProc;
            this.Parameters = para;
        }
    }
}
