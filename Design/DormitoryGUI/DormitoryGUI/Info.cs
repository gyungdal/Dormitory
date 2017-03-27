using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryGUI
{
    class Info
    {
        public class Server
        {
            private const string SERVER_URL = "http://dsm2015.cafe24.com:3141/";
            public const string LOGIN_URL = SERVER_URL + "login";
            public const string GET_PERMISSION_URL = SERVER_URL + "permission/get";
            public const string SET_PERMSSION_URL = SERVER_URL + "permission/set";
            public const string GET_MASTER_DATA = SERVER_URL + "info/master";
            public const string GET_DETAIL_DATA = SERVER_URL + "info/detail";
            public const string GET_SCORE_DATA = SERVER_URL + "scoreinfo/get";
        }
        public enum PERMISSION { ADMIN, DORMITORY_TEACHER, NORMAL_TEACHER, ERROR };
    }
}
