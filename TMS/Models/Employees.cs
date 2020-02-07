﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TMS.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<QTask> AssignedQTasks { get; set; } = new List<QTask>();
        public List<QTask> ReporteredQTasks { get; set; } = new List<QTask>();
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public enum EmployeeRole
    {
        Admin = 0,
        Manager = 1,
        Developer = 2,
    }

    public static class EmployeeEnum
    {
        public static SelectList RoleList(int? role = null)
        {
            return new SelectList(Enum.GetValues(typeof(EmployeeRole))
                                                      .Cast<EmployeeRole>()
                                                      .Select(r => new { Value = ((int)r).ToString(), Text = r.ToString() })
                                                      .ToList(), "Value", "Text", role ?? (int)EmployeeRole.Developer);
        }
    }
} 