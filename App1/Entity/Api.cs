using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Entity;

namespace App1.Constant
{
    class Api
    {
        public const string URL = "https://2-dot-backup-server-003.appspot.com";
        public const string MEMBER_REGISTER_URL = URL + "/_api/v2/members";
        public const string GET_UPLOAD_URL = URL + "/get-upload-token";
        public const string MEMBER_LOGIN_URL = URL + "/_api/v2/members/authentication";
        public const string MEMBER_GET_INFORMATION = URL + "/_api/v2/members/information";
        public const string SONG_CREATE_URL = URL + "/_api/v2/songs";
        public const string SONG_GET_ALL = URL + "/_api/v2/songs";
        public const string SONG_GET_MINE = URL + "/_api/v2/songs/get-mine";
        public static MemberCredential CurrentMemberCredential;

    }
}
