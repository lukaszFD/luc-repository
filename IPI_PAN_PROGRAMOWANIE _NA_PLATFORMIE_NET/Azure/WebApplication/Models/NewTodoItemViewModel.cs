﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class NewTodoItemViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
