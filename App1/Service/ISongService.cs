using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Entity;
using App1.view;

namespace App1.Service
{
    interface ISongService
    {
        Song CreateSong(Song song,  string token);
        List<Song> GetAllSong(MemberCredential memberCredential);
        List<Song> GetMineSongs(MemberCredential memberCredential);
    }
}
