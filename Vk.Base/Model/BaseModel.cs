﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Base.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int CreateUserId  { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime CrateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool  IsDeleted { get; set; }
    }
}
