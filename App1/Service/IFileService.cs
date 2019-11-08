using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Entity;

namespace App1.Service
{
    interface IFileService
    {
        Task<bool> SeveToFile(MemberCredential memberCredential);
        Task<MemberCredential> ReadFile();
        Task<bool> DeleteFile();
    }
}
