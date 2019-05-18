﻿using System;
using GameSpyLib.Logging;
using GameSpyLib.Database;
using RetroSpyServer.XMLConfig;
using System.Collections.Generic;

namespace RetroSpyServer.Extensions
{
    public class MasterServerDBQuery : DBQueryBase
    {
        public MasterServerDBQuery() : base()
        {
        }
        public MasterServerDBQuery(DatabaseDriver dbdriver) : base(dbdriver)
        {
        }




    }
}
