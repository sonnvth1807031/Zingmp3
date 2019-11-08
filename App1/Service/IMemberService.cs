using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Entity;

namespace App1.Service
{
    interface IMemberService
    {
        Member Register(Member member);

        MemberCredential Login(LoginMember memberLogin);

        Member GetInformation(string token);
    }
}
